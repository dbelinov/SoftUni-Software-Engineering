using System;

namespace _05.VacationType
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string location = "";
            string type = "";
            double cost = 0;

            if (budget <= 1000)
            {
                type = "Camp";
                if (season == "Summer")
                {
                    location = "Alaska";
                    cost = 0.65 * budget;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    cost = 0.45 * budget;
                }
            }
            else if (budget > 1000 && budget <= 3000)
            {
                type = "Hut";
                if (season == "Summer")
                {
                    location = "Alaska";
                    cost = 0.8 * budget;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    cost = 0.6 * budget;
                }
            }
            else
            {
                type = "Hotel";
                if (season == "Summer")
                {
                    location = "Alaska";
                    cost = 0.9 * budget;
                }
                else if (season == "Winter")
                {
                    location = "Morocco";
                    cost = 0.9 * budget;
                }
            }

            Console.WriteLine($"{location} - {type} - {cost:F2}");
        }
    }
}
