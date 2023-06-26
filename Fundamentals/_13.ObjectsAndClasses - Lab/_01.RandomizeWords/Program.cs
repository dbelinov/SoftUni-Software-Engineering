using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace _01.RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split()
                .ToList();

            Random random = new Random();
            for (int i = 0; i < input.Count; i++)
            {
                int randomIndex = random.Next(0, input.Count - 1);
                string temp = input[i];
                input[i] = input[randomIndex];
                input[randomIndex] = temp;
            }

            foreach (var word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
}