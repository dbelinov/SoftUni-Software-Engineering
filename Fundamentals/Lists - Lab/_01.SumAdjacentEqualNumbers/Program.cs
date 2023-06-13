using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.SumAdjacentEqualNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console
                .ReadLine()
                .Split()
                .Select(double.Parse)
                .ToList();

            int i = 0;

            while (i < numbers.Count - 1)
            {
                if (numbers[i] == numbers[i + 1])
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i + 1);
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}