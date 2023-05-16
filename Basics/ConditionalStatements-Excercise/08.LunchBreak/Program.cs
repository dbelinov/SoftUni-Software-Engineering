using System;

namespace _08.LunchBreak
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string seriesName = Console.ReadLine();
            double episodeLength = double.Parse(Console.ReadLine());
            double breakLength = double.Parse(Console.ReadLine());

            double lunchTime = (breakLength / 8);
            double relaxTime = (breakLength / 4);
            double remainingTime = (breakLength - (lunchTime + relaxTime));

            if (episodeLength <= remainingTime)
            {
                double timeToSpare = Math.Ceiling(remainingTime - episodeLength);
                Console.WriteLine($"You have enough time to watch {seriesName} and left with {timeToSpare} minutes free time.");
            }
            else
            {
                double neededTime = Math.Ceiling(episodeLength - remainingTime);
                Console.WriteLine($"You don't have enough time to watch {seriesName}, you need {neededTime} more minutes.");

                int a = 1550 % 10;
            }
        }
    }
}
