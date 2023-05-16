using System;

namespace _04.CarToGo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            string carClass = "";
            string carType = "";
            double carCost = 0;

            if(budget <= 100)
            {
                carClass = "Economy class";
                if (season == "Summer")
                {
                    carType = "Cabrio";
                    carCost = 0.35 * budget;
                }
                else if (season == "Winter")
                {
                    carType = "Jeep";
                    carCost = 0.65 * budget;
                }
            }
            else if (budget > 100 && budget <= 500)
            {
                carClass = "Compact class";
                if(season == "Summer")
                {
                    carType = "Cabrio";
                    carCost = 0.45 * budget;
                }
                else if (season == "Winter")
                {
                    carType = "Jeep";
                    carCost = 0.8 * budget;
                }
            }
            else if (budget > 500)
            {
                carClass = "Luxury class";
                carType = "Jeep";
                carCost = 0.9 * budget;
            }

            Console.WriteLine(carClass);
            Console.WriteLine($"{carType} - {carCost:F2}");
        }
    }
}
