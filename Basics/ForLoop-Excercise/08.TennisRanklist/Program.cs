using System;

namespace _08.TennisRanklist
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Read all input
            int countOfTournaments = int.Parse(Console.ReadLine());
            int initialPoints = int.Parse(Console.ReadLine());

            // 2. For loop
            // - sum of all points
            // - count of won tournaments
            // W (winner) - 2000
            // F (finalist) - 1200
            // SF (semi-finalist) - 720
            int newPoints = 0;
            int countOfWonTournaments = 0;
            for (int i = 0; i < countOfTournaments; i++)
            {
                string rank = Console.ReadLine();
                
                if (rank == "W")
                {
                    newPoints += 2000;
                    countOfWonTournaments++;
                }
                else if (rank == "F")
                {
                    newPoints += 1200;
                }
                else if (rank == "SF")
                {
                    newPoints += 720;
                }
            }

            // 3. Print output 
            // Final points - initialPoints + newPoints
            // Average points: - newPoints / countOfTournaments
            // Percent Won Tournaments - countOfWonTournaments / countOfTournaments * 100

            int finalPoints = initialPoints + newPoints;
            int averagePoints = newPoints / countOfTournaments; //Math.Floor with double
            double percentageOfWonTournaments = (double)countOfWonTournaments / countOfTournaments * 100;

            Console.WriteLine($"Final points: {finalPoints}");
            Console.WriteLine($"Average points: {averagePoints}");
            Console.WriteLine($"{percentageOfWonTournaments:f2}%");
        }
    }
}
