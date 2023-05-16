using System;

namespace _04.Grades
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int students = int.Parse(Console.ReadLine());

            double betweenTwoAndThree = 0;
            double betweenThreeAndFour = 0;
            double betweenFourAndFive = 0;
            double moreThanFive = 0;
            double totalGrade = 0;
            for(int i = 0; i < students; i++)
            {
                double grade = double.Parse(Console.ReadLine());

                if(grade >= 2 && grade <= 2.99)
                {
                    betweenTwoAndThree++;
                }
                else if(grade >= 3 && grade <= 3.99)
                {
                    betweenThreeAndFour++;
                }
                else if(grade >= 4 && grade <= 4.99)
                {
                    betweenFourAndFive++;
                }
                else
                {
                    moreThanFive++;
                }
                totalGrade += grade;
            }

            double averageGrade = totalGrade / students;

            double percentageFail = betweenTwoAndThree / students * 100;
            double percentage3To4 = betweenThreeAndFour / students * 100;
            double percentage4To5 = betweenFourAndFive / students * 100;
            double percentageTopStudents = moreThanFive / students * 100;

            Console.WriteLine($"Top students: {percentageTopStudents:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {percentage4To5:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {percentage3To4:f2}%");
            Console.WriteLine($"Fail: {percentageFail:f2}%");
            Console.WriteLine($"Average: {averageGrade:f2}");
        }
    }
}
