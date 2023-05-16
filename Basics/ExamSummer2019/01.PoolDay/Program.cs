using System;

namespace _01.PoolDay
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            double priceEntry = double.Parse(Console.ReadLine());
            double priceBed = double.Parse(Console.ReadLine());
            double priceUmbrella = double.Parse(Console.ReadLine());

            double costEntry = people * priceEntry;
            double costUmbrella = Math.Ceiling((double)people / 2) * priceUmbrella;
            double costBeds = Math.Ceiling(0.75 * people) * priceBed;
            double finalCost = costEntry + costUmbrella + costBeds;

            Console.WriteLine($"{finalCost:f2} lv.");
        }
    }
}
