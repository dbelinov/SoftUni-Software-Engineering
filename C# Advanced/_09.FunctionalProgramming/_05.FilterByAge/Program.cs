using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Channels;

namespace _05.FilterByAge
{
    class Person
    {
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string name = tokens[0];
                int age = int.Parse(tokens[1]);
                
                people.Add(new Person(name, age));
            }

            string condition = Console.ReadLine();
            int ageCond = int.Parse(Console.ReadLine());
            string filter = Console.ReadLine();

            Func<Person, int, bool> filterFunc;

            if (condition  == "older")
            {
                filterFunc = (person, number) => person.Age > number;
            }
            else
            {
                filterFunc = (person, number) => person.Age < number;
            }

            people = people.Where(x => filterFunc(x, ageCond)).ToList();

            Action<Person> formatter = FormatterGenerator(filter);

            people.ForEach(formatter);
            
            Action<Person> FormatterGenerator(string format)
            {
                if (filter == "name age")
                {
                    return s => Console.WriteLine($"{s.Name} - {s.Age}");
                }

                if (filter == "name")
                {
                    return s => Console.WriteLine($"{s.Name}");
                }

                if (filter == "age")
                {
                    return s => Console.WriteLine($"{s.Age}");
                }

                return default;
            }
        }
    }
}