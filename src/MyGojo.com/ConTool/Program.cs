using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConTool
{
    class Program
    {
        static void Main(string[] args)
        {

            string goodLogin = "GOJO-NET\\wades";
            string badLogin = "EXT-GOJO\\CarrB";
            string badLoginDomain = "GOJO-NET carrb";

            Console.WriteLine("{0}", RemoveDomain(goodLogin));
            Console.WriteLine("{0}", RemoveDomain(badLogin));
            Console.WriteLine("{0}", RemoveDomain(badLoginDomain));
            Console.ReadKey(true);
        }


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
}
