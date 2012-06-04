using System;
using System.Collections.Generic;
using System.Linq;

using Gojo.Core.Extensions;

namespace MyGojo.Core.Data.Parsers
{
    public class ArgParser
    {
        readonly Dictionary<string, Action>          mySwitches;
        readonly Dictionary<string, Action<string>>  mySwitchesWithArg;
        readonly Action<List<string>>                myOtherArgs;
        readonly List<Message>                       myMessages = new List<Message>();
        readonly char[]                              myDelimiters = new[] { '/', '-' }; 

        struct Message { public Levels Level; public string Text; }


        /// Construct a command line argument parser which can parse command line switches of the form /xxx -xxx.
        /// 
        /// switches:   Key is the command line switch. 
        ///             Value is an action that normally sets some boolean flag to true.
        ///             Must NOT be NULL
        /// 
        public ArgParser(Dictionary<string, Action> switches)
            : this(switches, null, null)
        { }

        /// Construct a command line argument parser which can parse command line switches of the form /xxx -xxx and switches with one parameter like -x argument.
        /// 
        /// switcheswithArg:    Key is the command line switch. 
        ///                     Value is an action that normally sets the passed parameter for this switch to a member variable. 
        /// Example:            "test.exe /files test.txt" will call the delegate with the name files in the dictionary with test.txt as parameter. 
        ///                     Can be NULL
        /// 
        public ArgParser(Dictionary<string, Action> switches, Dictionary<string, Action<string>> switcheswithArg)
            : this(switches, switcheswithArg, null)
        { }

        /// Construct a command line argument parser which can parse command line switches of the form /xxx -xxx and switches with one parameter like -x argument.
        /// 
        /// otherArgs:  Callback which is called with a list of the command line arguments which do not belong to a specific command line parameter. 
        /// Example:    "test.exe aaa bbb ccc" will call this method with an array with aaa, bbb, ccc. 
        ///             Can be NULL
        /// 
        public ArgParser(Dictionary<string, Action> switches, Dictionary<string, Action<string>> switcheswithArg, Action<List<string>> otherArgs)
        {
            if (switches == null)
                throw new ArgumentNullException("switches");

            mySwitches = CreateDictWithShortCuts(switches);
            myOtherArgs = otherArgs;

            if (switcheswithArg == null)
            {
                mySwitchesWithArg = new Dictionary<string, Action<string>>();
            }
            else
            {
                mySwitchesWithArg = CreateDictWithShortCuts(switcheswithArg);

                // check for duplicate keys 
                foreach (string key in mySwitches.Keys.Where(key => mySwitchesWithArg.ContainsKey(key)))
                {
                    throw new ArgumentException(String.Format("The command line switch -{0} occurs in both switches dictionaries. Please make it unambiguous.", key));
                }
            }
        }


        public bool ParseArgs(string[] args)
        {
            if (args.Length == 0)
            {
                // allow no arguments -- initially until fully developed application
                return true;

                //AddFormat(Levels.Error, "No arguments specified.");
                //return false;
            }

            for (int i = 0; i < args.Length; i++)
            {
                string arg = args[i];

                string parameter = (i + 1 < args.Length) ? args[i + 1] : null;      // get command line parameter for current argument if there is one
                parameter = IsSwitch(parameter) ? null : parameter;

                if (parameter != null)                                              // Advance counter to next argument which does not belong to the current one
                {
                    i++;
                }

                if (IsSwitch(arg))
                {
                    string strippedArg = arg.Substring(1).ToLower();                // command line switches are not case sensitive

                    if (mySwitches.OnValue(strippedArg))                            // Set Flag for simple command line switch
                    {
                        if (parameter != null)
                        {
                            if (myOtherArgs == null)
                            {
                                AddFormat(Levels.Error, "Superflous argument ({0}) for command line switch {1}", parameter, arg);
                            }
                            else                                                    // Other arguments present? process if this was the last command line argument
                            {
                                if (CallOtherArgs(args, i))                         // all arguments are processed when this returns true
                                {
                                    break;
                                }
                            }
                        }
                        continue;
                    }

                    bool? ret = mySwitchesWithArg.OnValueAndParameterNotNull(strippedArg, parameter);

                    switch (ret)
                    {
                        case null:
                            AddFormat(Levels.Error, "Unknown command line switch {0}", arg);
                            break;
                        case false:
                            AddFormat(Levels.Error, "Missing data for command line switch {0}", arg);
                            break;
                        default:
                            if (CallOtherArgs(args, i + 1))                         // all arguments are processed when this returns true
                            {
                                break;
                            }
                            break;
                    }
                }
                else
                {
                    if (CallOtherArgs(args, (parameter == null) ? i : i - 1))
                    {
                        break; // all arguments are processed when this returns true
                    }

                    AddFormat(Levels.Error, "Not a command line switch: {0}", arg);

                    if (parameter != null)
                    {
                        AddFormat(Levels.Error, "Not a command line switch: {0}", parameter);
                    }
                }
            }

            return myMessages.Count == 0;
        }

        public void AddFormat(Levels level, string format, params object[] args)
        {
            myMessages.Add(new Message { Level = level, Text = String.Format(format, args) });
        }

        public void PrintHelpWithMessages(string helpString)
        {
            if (helpString != null)
            {
                Console.WriteLine(helpString);
            }

            foreach (var message in myMessages)
            {
                string text = message.Text;
                if (message.Level == Levels.Warning)
                {
                    text = "Warning: " + text;
                }
                else if (message.Level == Levels.Error)
                {
                    text = "Error: " + text;
                }

                Console.WriteLine(text);
            }
        }

        
        private bool IsSwitch(string arg)
        {
            return !String.IsNullOrEmpty(arg) && Array.Exists(myDelimiters, (char c) => arg[0] == c);
        }

        /// Call the delegate for the "other" arguments when no more command line switches are present.
        /// 
        private bool CallOtherArgs(IList<string> args, int start)
        {
            List<string> ret = new List<string>();

            for (int i = start; i < args.Count; i++)
            {
                string curr = args[i];

                if (IsSwitch(curr)) // when a switch is found this is not the last argument. Do not process it
                {
                    ret = null;
                    break;
                }

                ret.Add(curr);
            }

            if (myOtherArgs != null && ret != null)
            {
                myOtherArgs(ret);
                return true;
            }

            return false;
        }

        private static Dictionary<string, T> CreateDictWithShortCuts<T>(Dictionary<string, T> switches)
        {
            Dictionary<string, T> ret = new Dictionary<string, T>();

            // Generate shortcut names from upper case letters of command line arguments
            foreach (var kvp in switches)
            {
                ret.Add(kvp.Key.ToLower(), kvp.Value);

                string shortCut = new string(  (from c in kvp.Key
                                                where Char.IsUpper(c)
                                                select c)
                                                .ToArray()
                                            ).ToLower();

                if (shortCut == "") continue;
                if (ret.ContainsKey(shortCut))
                {
                    throw new ArgumentException(
                        String.Format("The generated shortcut \"-{0}\" from \"-{1}\" collides with another command line switch.", shortCut, kvp.Key));
                }
                ret.Add(shortCut, kvp.Value);
            }
            return ret;
        }

    }


    public enum Levels
    {
        Info,
        Warning,
        Error
    }
}
