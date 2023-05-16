using System;

namespace _08.Graduation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();

            int gradeYear = 1;
            double totalGrade = 0;
            int badGrades = 0;

            while (gradeYear <= 12)
            {
                double grade = double.Parse(Console.ReadLine());

                if(grade < 4)
                {
                    badGrades++;

                    if(badGrades == 2)
                    {
                        Console.WriteLine($"{name} has been excluded at {gradeYear} grade");
                        return;
                    }
                    continue;
                }

                gradeYear++;
                totalGrade += grade;
            }

            double averageGrade = totalGrade / 12;
            Console.WriteLine($"{name} graduated. Average grade: {averageGrade:f2}");
        }
    }
}
