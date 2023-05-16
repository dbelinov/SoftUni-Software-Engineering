using System;

namespace _05.GodzillaVsKong
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double clothingPrice = double.Parse(Console.ReadLine());

            double decor = 0.1 * budget;
            double clothingCost = extras * clothingPrice;

            if (extras > 150)
            {
                clothingCost = 0.9 * clothingCost;
            }
            double moneyNeeded = decor + clothingCost;

            if (moneyNeeded <= budget)
            {
                double remaining = budget - moneyNeeded;
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {remaining:F2} leva left.");
            }
            else
            {
                double needed = moneyNeeded - budget;
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {needed:F2} leva more.");
            }
        }
    }
}
