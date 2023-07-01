using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.OrderByAge
{
    class Person
    {
        public Person(string name, string id, int age)
        {
            Name = name;
            Id = id;
            Age = age;
        }

        public string Name { get; set; }
        public string Id { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"{Name} with ID: {Id} is {Age} years old.";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string name = tokens[0];
                string id = tokens[1];
                int age = int.Parse(tokens[2]);

                Person foundPerson = people.FirstOrDefault(person => person.Id == id);
                if (foundPerson != null)
                {
                    foundPerson.Name = name;
                    foundPerson.Age = age;
                }
                else
                {
                    Person person = new Person(name, id, age);
                    people.Add(person);
                }
            }

            List<Person> orderedPeople = people.OrderBy(person => person.Age).ToList();

            foreach (var person in orderedPeople)
            {
                Console.WriteLine(person);
            }
        }
    }
}