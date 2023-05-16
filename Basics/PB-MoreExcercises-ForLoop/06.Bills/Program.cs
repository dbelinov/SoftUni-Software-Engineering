using System;

namespace _06.Bills
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int months = int.Parse(Console.ReadLine());

            double waterPrice = 20;
            double internetPrice = 15;

            double powerCost = 0;
            double waterCost = 0;
            double internetCost = 0;
            double otherCost = 0;
            double totalCost = 0;

            for (int i = 0;  i < months; i++)
            {
                double powerPerMonth = double.Parse(Console.ReadLine());

                powerCost += powerPerMonth;
                waterCost += waterPrice;
                internetCost += internetPrice;
                otherCost += 1.2 * (waterPrice + internetPrice + powerPerMonth);
            }
            totalCost += powerCost + waterCost + internetCost + otherCost;

            double averageCost = totalCost / months;

            Console.WriteLine($"Electricity: {powerCost:f2} lv");
            Console.WriteLine($"Water: {waterCost:f2} lv");
            Console.WriteLine($"Internet: {internetCost:f2} lv");
            Console.WriteLine($"Other: {otherCost:f2} lv");
            Console.WriteLine($"Average: {averageCost:f2} lv");
        }
    }
}
