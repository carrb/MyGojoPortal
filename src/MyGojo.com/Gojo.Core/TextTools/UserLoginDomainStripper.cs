using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Gojo.Core.TextTools
{
    public class UserLoginDomainStripper
    {

        public static string RemoveDomain(string login)
        {
            if (!login.Contains("\\")) return login;

            Regex regex = new Regex(@"(\w+)\\(\w+)", RegexOptions.Singleline, TimeSpan.FromMilliseconds(1));
            Match match = regex.Match(login);

            Console.WriteLine("First part: {0}, Second part: {1}", match.Groups[1].ToString().ToLowerInvariant(), match.Groups[2].ToString().ToLowerInvariant());

            // 1 - Strip Domain from login (Ex: 'GOJO-NET\wades' becomes 'wades'
            

            // 2 - lowercase remaining
            //login = login.ToLowerInvariant();


            return login;
        }

        /*
        private static string ReplaceNonWordWithDashes(string title)
        {
            // Remove Apostrophe Tags
            title = Regex.Replace(title, "[’'“”\"&]{1,}", "", RegexOptions.None);

            // Replaces all non-alphanumeric character by a space
            var builder = new StringBuilder();
            for (int i = 0; i < title.Length; i++)
            {
                builder.Append(char.IsLetterOrDigit(title[i]) ? title[i] : ' ');
            }

            title = builder.ToString();

            // Replace multiple spaces into a single dash
            title = Regex.Replace(title, "[ ]{1,}", "-", RegexOptions.None);

            return title;
        }


        private string IsolateLogin(string login)
        {
            try
            {
                Regex regexpr = new Regex(@"GOJO-NET\\(\w+)", RegexOptions.Singleline, TimeSpan.FromMilliseconds(1));

                Match mtch = regexpr.Match(login);

                Console.WriteLine("{0}", mtch.Groups[1]);

                if (mtch.Success)
                    return (@"GOJO-NET\" + mtch.Groups[1].ToString().ToLowerInvariant());
                return login;
            }
            catch (RegexMatchTimeoutException ex)
            {
                //Console.WriteLine("Regex Timeout for {1} after {2} elapsed. Tried pattern {0}", ex.Pattern, ex.Message, ex.MatchTimeout);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Console.WriteLine(ex.ToString());
            }

            return login;
        }
         * */
    }
}
