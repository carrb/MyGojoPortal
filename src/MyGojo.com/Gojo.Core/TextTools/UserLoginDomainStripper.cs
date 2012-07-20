using System;
using System.Text.RegularExpressions;

namespace Gojo.Core.TextTools
{
    public class UserLoginDomainStripper
    {
        public static string RemoveDomain(string login)
        {
            if (!login.Contains("\\")) return login;

            try
            {
                Regex regex = new Regex(@"^.+\\(\w+)", RegexOptions.Singleline, TimeSpan.FromMilliseconds(1));
                Match match = regex.Match(login);

                return match.Success ? match.Groups[1].ToString().ToLowerInvariant() : login;
            }
            catch (RegexMatchTimeoutException ex)
            {
                Console.WriteLine("Regex Timeout for {1} after {2} elapsed. Tried pattern {0}", ex.Pattern, ex.Message, ex.MatchTimeout);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return login;
        }
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
        */
   
}
