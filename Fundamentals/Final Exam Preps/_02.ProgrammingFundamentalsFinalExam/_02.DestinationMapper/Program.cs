using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.DestinationMapper
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string pattern = @"([=/])(?<Country>[A-Z][A-Za-z]{2,})\1";

            var matches = Regex.Matches(input, pattern);
            List<string> countries = new List<string>();
            foreach (Match match in matches)
            {
                countries.Add(match.Groups["Country"].Value);
            }
            int travelPoints = countries.Sum(x => x.Length);

            Console.WriteLine($"Destinations: {string.Join(", ", countries)}");
            Console.WriteLine($"Travel Points: {travelPoints}");
        }
    }
}