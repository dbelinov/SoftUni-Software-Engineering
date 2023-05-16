using System;

namespace _05.Pets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int foodAvailable = int.Parse(Console.ReadLine()); //kg
            double dogFoodPerDay = double.Parse(Console.ReadLine()); //kg
            double catFoodPerDay = double.Parse(Console.ReadLine()); //kg
            double turtleFoodPerDay = double.Parse(Console.ReadLine()); //g

            double turtleFoodPerDayInKg = turtleFoodPerDay / 1000;

            double dogFood = dogFoodPerDay * days;
            double catFood = catFoodPerDay * days;
            double turtleFood = turtleFoodPerDayInKg * days;
            double allFood = dogFood + catFood + turtleFood;

            if (foodAvailable >= allFood)
            {
                double remainingFood = foodAvailable - allFood;
                Console.WriteLine($"{Math.Floor(remainingFood)} kilos of food left.");
            }
            else
            {
                double neededFood = allFood - foodAvailable;
                Console.WriteLine($"{Math.Ceiling(neededFood)} more kilos of food are needed.");
            }
        }
    }
}
