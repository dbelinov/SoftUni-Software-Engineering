using System;

namespace _02.BraceletStand
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double pocketMoney = double.Parse(Console.ReadLine());
            double moneyPerDayWon = double.Parse(Console.ReadLine());
            double razhodiForWholePeriod = double.Parse(Console.ReadLine());
            double pricePresent = double.Parse(Console.ReadLine());

            double finalMoney = pocketMoney * 5 + moneyPerDayWon * 5 - razhodiForWholePeriod;

            if (finalMoney >= pricePresent)
            {
                Console.WriteLine($"Profit: {finalMoney:f2} BGN, the gift has been purchased.");
            }
            else
            {
                Console.WriteLine($"Insufficient money: {pricePresent - finalMoney:f2} BGN.");
            }
        }
    }
}
