using System;
using System.Runtime.CompilerServices;

namespace _04.FishingBoat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishers = int.Parse(Console.ReadLine());

            double priceBoat = 0;

            switch(season)
            {
                case "Spring":
                    priceBoat = 3000;
                    break;
                case "Summer":
                case "Autumn":
                    priceBoat = 4200;
                    break;
                case "Winter":
                    priceBoat = 2600;
                    break;
            }

            if (fishers <= 6)
            {
                priceBoat = 0.9 * priceBoat;
            }
            else if (fishers >= 7 && fishers <= 11)
            {
                priceBoat = 0.85 * priceBoat;
            }
            else if (fishers >= 12)
            {
                priceBoat = 0.75 * priceBoat;
            }

            if (fishers % 2 == 0 && season != "Autumn")
            {
                priceBoat = 0.95 * priceBoat;
            }

            if (budget >= priceBoat)
            {
                double remaining = budget - priceBoat;
                Console.WriteLine($"Yes! You have {remaining:F2} leva left.");
            }
            else
            {
                double needed = priceBoat - budget;
                Console.WriteLine($"Not enough money! You need {needed:F2} leva.");
            }
        }
    }
}
