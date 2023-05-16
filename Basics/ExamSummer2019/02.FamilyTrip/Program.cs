using System;

namespace _02.FamilyTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            double pricePerNight = double.Parse(Console.ReadLine());
            int percentForMoreExpenses = int.Parse(Console.ReadLine());

            if (nights > 7)
            {
                pricePerNight = 0.95 * pricePerNight;
            }

            double expenses = nights * pricePerNight + (double) percentForMoreExpenses / 100 * budget;

            if(expenses <= budget)
            {
                Console.WriteLine($"Ivanovi will be left with {budget - expenses:f2} leva after vacation.");
            }
            else
            {
                Console.WriteLine($"{expenses - budget:f2} leva needed.");
            }
        }
    }
}
