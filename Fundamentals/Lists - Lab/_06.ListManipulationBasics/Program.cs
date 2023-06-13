using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        break;
                    case "RemoveAt":
                        int removedIndex = int.Parse(tokens[1]);
                        numbers.RemoveAt(removedIndex);
                        break;
                    case "Insert":
                        int numberToBeInserted = int.Parse(tokens[1]);
                        int indexToBeAddedAt = int.Parse(tokens[2]);
                        numbers.Insert(indexToBeAddedAt, numberToBeInserted);
                        break;                        
                }
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}