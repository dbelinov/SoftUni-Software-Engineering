using System;

namespace GodzillaVsKong
{
    class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int stunters = int.Parse(Console.ReadLine());
            double pricePerCostume = double.Parse(Console.ReadLine());

            double priceDecor = 0.1 * budget;

            double priceCostumes = stunters * pricePerCostume;
            if (stunters > 150)
            {
                priceCostumes = 0.9 * priceCostumes;
            }

            double cost = priceCostumes + priceDecor;
            
            if (cost <= budget)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {budget - cost:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(cost - budget):f2} leva more.");
            }
        }
    }
}