using System;
using System.Text.RegularExpressions;

namespace _03.MatchDates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<Day>\d{2})(.|-|/)(?<Month>[A-Z][a-z]{2})\1(?<Year>\d{4})\b";
            string input = Console.ReadLine();

            var dates = Regex.Matches(input, pattern);

            foreach (Match match in dates)
            {
                var day = match.Groups["Day"].Value;
                var month = match.Groups["Month"].Value;
                var year = match.Groups["Year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }

        }
    }
}