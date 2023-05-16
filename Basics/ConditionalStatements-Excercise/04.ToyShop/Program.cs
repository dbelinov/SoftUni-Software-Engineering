using System;

namespace _04.ToyShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double breakPrice = double.Parse(Console.ReadLine());
            int puzzles = int.Parse(Console.ReadLine());
            int dolls = int.Parse(Console.ReadLine());
            int bears = int.Parse(Console.ReadLine());
            int minions = int.Parse(Console.ReadLine());
            int trucks = int.Parse(Console.ReadLine());

            int allToys = puzzles + dolls + bears + minions + trucks;

            double price = puzzles * 2.60 + dolls * 3 + bears * 4.10 + minions * 8.20 + trucks * 2;

            if (allToys >= 50)
            {
                price = 0.75 * price;
            }

            double moneyLeft = 0.9 * price;

            if (moneyLeft >= breakPrice)
            {
                double remainingMoney = moneyLeft - breakPrice;
                Console.WriteLine($"Yes! {remainingMoney:F2} lv left.");
            }
            else
            {
                double moneyNeed = breakPrice - moneyLeft;
                Console.WriteLine($"Not enough money! {moneyNeed:F2} lv needed.");
            }
        }
    }
}
