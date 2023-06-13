using System;

namespace _02.Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            string gradeInWords = GradeChecker(grade);

            Console.WriteLine(gradeInWords);
        }

        private static string GradeChecker(double grade)
        {
            if (grade >= 2.00 && grade <= 2.99)
                return "Fail";
            if (grade >= 3.00 && grade <= 3.49)
                return "Poor";
            if (grade >= 3.50 && grade <= 4.49)
                return "Good";
            if (grade >= 4.50 && grade <= 5.49)
                return "Very good";
            return "Excellent";
        }
    }
}