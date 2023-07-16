using System;
using System.Text.RegularExpressions;
/*
+359 2 222 2222,359-2-222-2222, +359/2/222/2222, +359-2 222 2222 +359 2-222-2222, +359-2-222-222, +359-2-222-22222 +359-2-222-2222
*/

namespace _02.MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\+359( |-)2\1\d{3}\1\d{4}\b";
            string input = Console.ReadLine();

            var matchedPhones = Regex.Matches(input, pattern);

            Console.WriteLine(String.Join(", ", matchedPhones));
        }
    }
}