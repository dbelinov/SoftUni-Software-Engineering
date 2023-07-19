using System;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
/*
#Bread#19/03/21#4000#|Invalid|03/03.20||Apples|08/10/20|200||Carrots|06/08/20|500||Not right|6.8.20|5|
*/

namespace _02.AdAstra
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([#|])(?<Name>[A-Z-a-z ]+)\1(?<ExpirationDate>\d{2}/\d{2}/\d{2})\1(?<Calories>\d+)\1";
            var matches = Regex.Matches(input, pattern);
            int totalCalories = 0;
            foreach (Match match in matches)
            {
                totalCalories += int.Parse(match.Groups["Calories"].Value);
            }

            int daysToSurvive = totalCalories / 2000;

            Console.WriteLine($"You have food to last you for: {daysToSurvive} days!");
            foreach (Match match in matches)
            {
                string name = match.Groups["Name"].Value;
                string expiry = match.Groups["ExpirationDate"].Value;
                int calories = int.Parse(match.Groups["Calories"].Value);

                Console.WriteLine($"Item: {name}, Best before: {expiry}, Nutrition: {calories}");
            }
        }
    }
}