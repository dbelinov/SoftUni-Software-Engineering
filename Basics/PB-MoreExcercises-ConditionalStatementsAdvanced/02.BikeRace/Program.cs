using System;

namespace _02.BikeRace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int youngBikers = int.Parse(Console.ReadLine());
            int elderlyBikers = int.Parse(Console.ReadLine());
            string traceType = Console.ReadLine();

            double youngCost = 0;
            double elderlyCost = 0;

            if (traceType == "trail")
            {
                youngCost = 5.50 * youngBikers;
                elderlyCost = 7 * elderlyBikers;
            }
            else if (traceType == "cross-country")
            {
                youngCost = 8 * youngBikers;
                elderlyCost = 9.50 * elderlyBikers;
            }
            else if (traceType == "downhill")
            {
                youngCost = 12.25 * youngBikers;
                elderlyCost = 13.75 * elderlyBikers;
            }
            else if (traceType == "road")
            {
                youngCost = 20 * youngBikers;
                elderlyCost = 21.50 * elderlyBikers;
            }

            double finalReward = youngCost + elderlyCost;

            if ((youngBikers + elderlyBikers) >= 50 && traceType == "cross-country")
            {
                finalReward = 0.75 * finalReward;
            }

            double forCharity = 0.95 * finalReward;

            Console.WriteLine($"{forCharity:F2}");

        }
    }
}
