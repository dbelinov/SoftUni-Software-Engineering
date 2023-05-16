using System;

namespace _08.FuelTank02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());
            string clubCard = Console.ReadLine();

            double cost = 0;

            if(fuelType == "Gas")
            {
                cost = amount * 0.93;
            }
            else if (fuelType == "Gasoline")
            {
                cost = amount * 2.22;
            }
            else if (fuelType == "Diesel")
            {
                cost = amount * 2.33;
            }

            if (clubCard == "Yes")
            {
                if (fuelType == "Gas")
                {
                    cost = cost - amount * 0.08;
                }
                else if (fuelType == "Gasoline")
                {
                    cost = cost - amount * 0.18;
                }
                else if (fuelType == "Diesel")
                {
                    cost = cost - amount * 0.12;
                }
            }

            if (amount >= 20 && amount <= 25)
            {
                cost = 0.92 * cost;
            }
            else if (amount > 25)
            {
                cost = 0.9 * cost;
            }

            Console.WriteLine($"{cost:F2} lv.");
        }
    }
}
