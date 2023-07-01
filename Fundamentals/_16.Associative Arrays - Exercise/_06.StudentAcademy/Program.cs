using System;
using System.Collections.Generic;
using System.Linq;

/*
5
John
5.5
John
4.5
Alice
6
Alice
3
George
5

5
Amanda
3.5
Amanda
4
Rob
5.5
Christian
5
Robert
6
*/

namespace _06.StudentAcademy
{
    class Student
    {
        public Student(string name, double grade)
        {
            Name = name;
            Grade = grade;
        }

        public string Name { get; set; }
        public double Grade { get; set; }

        public List<double> Grades = new List<double>();

        public double GetAverageGrade()
        {
            double averageGrade = 0;
            foreach (var grade in Grades)
            {
                averageGrade += grade;
            }

            averageGrade /= Grades.Count;
            return averageGrade;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            Dictionary<string, Student> students = new Dictionary<string, Student>();
            for (int i = 0; i < rows; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(name))
                {
                    Student student = new Student(name, grade);
                    students.Add(name, student);
                }
                
                students[name].Grades.Add(grade);
            }

            Dictionary<string, double> updatedStudents = new Dictionary<string, double>();
            foreach (var student in students)
            {
                updatedStudents.Add(student.Key, student.Value.GetAverageGrade());
            }

            foreach (var student in updatedStudents)
            {
                if (student.Value < 4.50)
                {
                    updatedStudents.Remove(student.Key);
                }
            }

            foreach (var student in updatedStudents)
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}