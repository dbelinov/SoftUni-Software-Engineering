using System;

namespace _07.Shopping
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int gpus = int.Parse(Console.ReadLine());
            int cpus = int.Parse(Console.ReadLine());
            int ram = int.Parse(Console.ReadLine());

            double priceGpus = gpus * 250;
            double priceCpus = 0.35 * priceGpus * cpus;
            double priceRam = 0.1 * priceGpus * ram;
            double finalPrice = priceGpus + priceCpus + priceRam;
            if (gpus > cpus)
            {
                finalPrice = 0.85 * finalPrice;
            }


            if (finalPrice <= budget)
            {
                double remainingMoney = budget - finalPrice;
                Console.WriteLine($"You have {remainingMoney:F2} leva left!");
            }
            else
            {
                double neededMoney = finalPrice - budget;
                Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva more!");
            }

        }
    }
}
