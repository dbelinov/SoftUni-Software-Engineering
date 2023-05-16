using System;

namespace _04.VegetableMarket
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double priceVegetables = double.Parse(Console.ReadLine());
            double priceFruits = double.Parse(Console.ReadLine());
            int vegetables = int.Parse(Console.ReadLine());
            int fruits = int.Parse(Console.ReadLine());

            double vegetableCost = priceVegetables * vegetables;
            double fruitsCost = priceFruits * fruits;
            double totalCost = vegetableCost + fruitsCost;
            double euroCost = totalCost / 1.94;

            Console.WriteLine($"{euroCost:F2}");
        }
    }
}
