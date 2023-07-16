using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace _01.MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]{1,}[ ][A-Z][a-z]{1,}\b";
            string input = Console.ReadLine();

            Regex regex = new Regex(pattern);
            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.Write(match + " ");
            }
        }
    }
}