using System;

namespace _02.ExamPreparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxBadGrades = int.Parse(Console.ReadLine());

            int badGrades = 0;
            string input = Console.ReadLine();
            int sum = 0;
            string lastProblem = "";
            int gradesAmount = 0;

            while (input != "Enough") 
            {
                int grade = int.Parse(Console.ReadLine());

                if (grade <= 4)
                {
                    badGrades++;
                    
                    if (badGrades == maxBadGrades)
                    {
                        Console.WriteLine($"You need a break, {badGrades} poor grades.");
                        return;
                    }
                }

                sum += grade;
                lastProblem = input;
                input = Console.ReadLine();
                gradesAmount++;
            }

            Console.WriteLine($"Average score: {(double) sum / gradesAmount:f2}");
            Console.WriteLine($"Number of problems: {gradesAmount}");
            Console.WriteLine($"Last problem: {lastProblem}");
        }
    }
}
