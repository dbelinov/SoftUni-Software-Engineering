using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Students2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
                string firstName = tokens[0];
                string lastName = tokens[1];
                int age = int.Parse(tokens[2]);
                string homeTown = tokens[3];

                Student student = students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
                if (student == null)
                {
                    students.Add(new Student(firstName, lastName, age, homeTown));
                }
                else
                {
                    student.HomeTown = homeTown;
                    student.Age = age;
                }
            }

            string printCity = Console.ReadLine();

            List<Student> filteredList = students.Where(student => student.HomeTown == printCity).ToList();

            foreach (Student student in filteredList)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }

    class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
}