using System;
using System.ComponentModel;

namespace _06.FlowerShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int magnolias = int.Parse(Console.ReadLine());
            int hyacinths = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int cactus = int.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());

            double magnoliasCost = magnolias * 3.25;
            double hyacinthsCost = hyacinths * 4;
            double rosesCost = roses * 3.5;
            double cactusCost = cactus * 8;
            double allCost = magnoliasCost + hyacinthsCost + rosesCost + cactusCost;
            double profit = 0.95 * allCost;

            if(profit >= price)
            {
                double remaining = profit - price;
                Console.WriteLine($"She is left with {Math.Floor(remaining)} leva.");
            }
            else
            {
                double needed = price - profit;
                Console.WriteLine($"She will have to borrow {Math.Ceiling(needed)} leva.");
            }
        }
    }
}
