using System;

namespace _07.FuelTank01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fuelType = Console.ReadLine();
            double availableLiters = double.Parse(Console.ReadLine());
            
            if (availableLiters >= 25)
            {
                if (fuelType == "Diesel")
                {
                    Console.WriteLine("You have enough diesel.");
                }
                else if (fuelType == "Gasoline")
                {
                    Console.WriteLine("You have enough gasoline.");
                }
                else if (fuelType == "Gas")
                {
                    Console.WriteLine("You have enough gas.");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }
            else
            {
                if (fuelType == "Diesel")
                {
                    Console.WriteLine("Fill your tank with diesel!");
                }
                else if (fuelType == "Gasoline")
                {
                    Console.WriteLine("Fill your tank with gasoline!");
                }
                else if (fuelType == "Gas")
                {
                    Console.WriteLine("Fill your tank with gas!");
                }
                else
                {
                    Console.WriteLine("Invalid fuel!");
                }
            }
        }
    }
}
