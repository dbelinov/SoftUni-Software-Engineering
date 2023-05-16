using System;

namespace _04.TrainTheTrainers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            double sumGrades = 0;
            double averageForCurrent = 0;
            double sumAll = 0;
            int counter = 0;

            while (input != "Finish")
            {
                sumGrades = 0;
                for (int i = 1; i <= n; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    sumGrades += grade;
                    sumAll += grade;
                    counter++;
                }
                averageForCurrent = sumGrades / n;

                Console.WriteLine($"{input} - {averageForCurrent:f2}.");

                input = Console.ReadLine();
            }

            double finalAssessment = sumAll / counter;
            Console.WriteLine($"Student's final assessment is {finalAssessment:f2}.");
        }
    }
}
