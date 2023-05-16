using System;
using System.Globalization;

namespace _06.Oscars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string actorName = Console.ReadLine();
            double pointsFromAcademy = double.Parse(Console.ReadLine());
            int judges = int.Parse(Console.ReadLine());

            double totalPoints = pointsFromAcademy;

            for (int i = 0; i < judges && totalPoints <= 1250.5; i++)
            {
                string judgeName = Console.ReadLine();
                double pointsFromJudge = double.Parse(Console.ReadLine());

                totalPoints += judgeName.Length * pointsFromJudge / 2;
            }

            if (totalPoints > 1250.5)
            {
                Console.WriteLine($"Congratulations, {actorName} got a nominee for leading role with {totalPoints:f1}!");
            }
            else
            {
                double diff = 1250.5 - totalPoints;
                Console.WriteLine($"Sorry, {actorName} you need {diff:f1} more!");
            }
        }
    }
}
