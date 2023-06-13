using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.ListManipulationAdvanced
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            bool changesAreMade = false;
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "Add":
                        int numberToAdd = int.Parse(tokens[1]);
                        numbers.Add(numberToAdd);
                        changesAreMade = true;
                        break;
                    case "Remove":
                        int numberToRemove = int.Parse(tokens[1]);
                        numbers.Remove(numberToRemove);
                        changesAreMade = true;
                        break;
                    case "RemoveAt":
                        int removedIndex = int.Parse(tokens[1]);
                        numbers.RemoveAt(removedIndex);
                        changesAreMade = true;
                        break;
                    case "Insert":
                        int numberToBeInserted = int.Parse(tokens[1]);
                        int indexToBeAddedAt = int.Parse(tokens[2]);
                        numbers.Insert(indexToBeAddedAt, numberToBeInserted);
                        changesAreMade = true;
                        break;   
                    case "Contains":
                        int numberToBeContained = int.Parse(tokens[1]);
                        if (numbers.Contains(numberToBeContained))
                            Console.WriteLine("Yes");
                        else
                            Console.WriteLine("No such number");
                        break;
                    case "PrintEven":
                        List<int> evenNums = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 == 0)
                                evenNums.Add(numbers[i]);
                        }

                        Console.WriteLine(String.Join(' ', evenNums));
                        break;
                    case "PrintOdd":
                        List<int> oddNums = new List<int>();
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (numbers[i] % 2 != 0)
                                oddNums.Add(numbers[i]);
                        }

                        Console.WriteLine(String.Join(' ', oddNums));
                        break;
                    case "GetSum":
                        int sum = 0;
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            sum += numbers[i];
                        }

                        Console.WriteLine(sum);
                        break;
                    case "Filter":
                        string condition = tokens[1];
                        int number = int.Parse(tokens[2]);

                        if (condition == "<")
                        {
                            foreach (var item in numbers)
                            {
                                if (item < number)
                                {
                                    Console.Write(item + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (condition == ">")
                        {
                            foreach (var item in numbers)
                            {
                                if (item > number)
                                {
                                    Console.Write(item + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (condition == "<=")
                        {
                            foreach (var item in numbers)
                            {
                                if (item <= number)
                                {
                                    Console.Write(item + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        else if (condition == ">=")
                        {
                            foreach (var item in numbers)
                            {
                                if (item >= number)
                                {
                                    Console.Write(item + " ");
                                }
                            }
                            Console.WriteLine();
                        }
                        break;
                }
            }

            if (changesAreMade)
            {
                Console.WriteLine(String.Join(' ', numbers));
            }
        }
    }
}