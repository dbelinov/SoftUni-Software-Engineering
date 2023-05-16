using System;

namespace _06.TruckDriver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string season = Console.ReadLine();
            double kmPerMonth = double.Parse(Console.ReadLine());

            double payRate = 0;

            if (kmPerMonth <= 5000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    payRate = 0.75;
                }
                else if (season == "Summer")
                {
                    payRate = 0.9;
                }
                else if (season == "Winter")
                {
                    payRate = 1.05;
                }
            }
            else if (kmPerMonth > 5000 && kmPerMonth <= 10000)
            {
                if (season == "Spring" || season == "Autumn")
                {
                    payRate = 0.95;
                }
                else if (season == "Summer")
                {
                    payRate = 1.1;
                }
                else if (season == "Winter")
                {
                    payRate = 1.25;
                }
            }
            else
            {
                payRate = 1.45;
            }

            double salary = 4 * kmPerMonth * payRate;
            double finalPay = 0.9 * salary;

            Console.WriteLine($"{finalPay:F2}");
        }
    }
}
