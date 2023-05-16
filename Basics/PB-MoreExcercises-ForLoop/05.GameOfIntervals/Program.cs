using System;

namespace _05.GameOfIntervals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moves = int.Parse(Console.ReadLine());
            double points = 0;
            int zeroToNine = 0;
            int tenToNineteen = 0;
            int twentyToTwentyNine = 0;
            int thirtyToThirtyNine = 0;
            int fortyToFifty = 0;
            int invalid = 0;
            

            for (int i = 0; i < moves; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (number >= 0 && number <= 9)
                {
                    points += 0.2 * number;
                    zeroToNine++;
                }
                else if (number >= 10 && number <= 19)
                {
                    points += 0.3 * number;
                    tenToNineteen++;
                }
                else if (number >= 20 && number <= 29)
                {
                    points += 0.4 * number;
                    twentyToTwentyNine++;
                }
                else if (number >= 30 && number <= 39)
                {
                    points += 50;
                    thirtyToThirtyNine++;
                }
                else if (number >= 40 && number <= 50)
                {
                    points += 100;
                    fortyToFifty++;
                }
                else
                {
                    points = points / 2;
                    invalid++;
                }
            }

            double firstPercent = zeroToNine / moves * 100;
            double secondPercent = tenToNineteen / moves * 100;
            double thirdPercent = twentyToTwentyNine / moves * 100;
            double fourthPercent = thirtyToThirtyNine / moves * 100;
            double fifthPercent = fortyToFifty / moves * 100;
            double invalidPercent = invalid / moves * 100;

            Console.WriteLine($"{points:f2}");
            Console.WriteLine($"From 0 to 9: {firstPercent:f2}%");
            Console.WriteLine($"From 10 to 19: {secondPercent:f2}%");
            Console.WriteLine($"From 20 to 29: {thirdPercent:f2}%");
            Console.WriteLine($"From 30 to 39: {fourthPercent:f2}%");
            Console.WriteLine($"From 40 to 50: {fifthPercent:f2}%");
            Console.WriteLine($"Invalid numbers: {invalidPercent:f2}%");
        }
    }
}
