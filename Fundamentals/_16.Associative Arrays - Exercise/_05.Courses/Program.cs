using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

/*
Programming Fundamentals : John Smith
Programming Fundamentals : Linda Johnson
JS Core : Will Wilson
Java Advanced : Harrison White
end
*/

namespace _05.Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(" : ");
                string name = tokens[0];
                string student = tokens[1];

                if (!courses.ContainsKey(name))
                {
                    courses.Add(name, new List<string>());
                }
                
                courses[name].Add(student);
            }

            foreach (var course in courses)
            {
                Console.WriteLine($"{course.Key}: {course.Value.Count}");
                foreach (var user in course.Value)
                {
                    Console.WriteLine($"-- {user}");
                }
            }
        }
    }
}