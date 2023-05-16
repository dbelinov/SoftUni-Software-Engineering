using System;

namespace _03.Harvest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int area = int.Parse(Console.ReadLine());
            double grapes = double.Parse(Console.ReadLine());
            int wine = int.Parse(Console.ReadLine());
            int workers = int.Parse(Console.ReadLine());

            double grapesAmount = area * grapes;
            double wineLiters = 0.4 * grapesAmount / 2.5;

            if(wineLiters < wine)
            {
                double neededWine = wine - wineLiters;
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(neededWine)} liters wine needed.");
            }
            else if (wineLiters >= wine)
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(wineLiters)} liters.");
                double remainingWine = wineLiters - wine;
                double winePerPerson = remainingWine / workers;
                Console.WriteLine($"{Math.Ceiling(remainingWine)} liters left -> {Math.Ceiling(winePerPerson)} liters per person.");
            }
        }
    }
}
