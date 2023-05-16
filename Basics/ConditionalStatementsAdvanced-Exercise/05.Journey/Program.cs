using System;

namespace _05.Journey
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string location = "";
            double cost = 0;
            string type = "";

            if (budget <= 100)
            {
                location = "Bulgaria";
                if (season == "summer")
                {
                    cost = 0.3 * budget;
                    type = "Camp";
                }
                else if (season == "winter")
                {
                    cost = 0.7 * budget;
                    type = "Hotel";
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                location = "Balkans";
                if (season == "summer")
                {
                    cost = 0.4 * budget;
                    type = "Camp";
                }
                else if (season == "winter")
                {
                    cost = 0.8 * budget;
                    type = "Hotel";
                }
            }
            else if (budget > 1000)
            {
                location = "Europe";
                cost = 0.9 * budget;
                type = "Hotel";
            }

            Console.WriteLine($"Somewhere in {location}");
            Console.WriteLine($"{type} - {cost:F2}");
        }
    }
}
