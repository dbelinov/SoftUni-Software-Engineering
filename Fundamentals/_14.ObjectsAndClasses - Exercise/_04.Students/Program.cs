﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfStudents = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < numberOfStudents; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string firstName = tokens[0];
                string lastName = tokens[1];
                double grade = double.Parse(tokens[2]);

                Student student = new Student(firstName, lastName, grade);
                students.Add(student);
            }

            List<Student> sortedStudents = students.OrderByDescending(student => student.Grade).ToList();
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, double grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}