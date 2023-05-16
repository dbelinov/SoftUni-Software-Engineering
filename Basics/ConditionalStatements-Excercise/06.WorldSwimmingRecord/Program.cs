using System;

namespace _06.WorldSwimmingRecord
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double recordInSeconds = double.Parse(Console.ReadLine());
            double distanceInMeters = double.Parse(Console.ReadLine());
            double timeToSwim1mInSeconds = double.Parse(Console.ReadLine());

            double timeToSwimDistance = distanceInMeters * timeToSwim1mInSeconds;

            double resistance = Math.Floor(distanceInMeters / 15) * 12.5;
            double totalTime = timeToSwimDistance + resistance;

            if (totalTime < recordInSeconds)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {totalTime:F2} seconds.");
            }
            else
            {
                double needed = totalTime - recordInSeconds;
                Console.WriteLine($"No, he failed! He was {needed:F2} seconds slower.");
            }
        }
    }
}
