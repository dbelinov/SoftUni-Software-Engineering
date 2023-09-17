﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nsx = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int numberOfElements = nsx[0];
            int elementsToPop = nsx[1];
            int elementToFind = nsx[2];

            Stack<int> numbers = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            for (int i = 0; i < elementsToPop; i++) //possible overflow
            {
                numbers.Pop();
            }

            if (numbers.Count > 0)
            {
                if (numbers.Contains(elementToFind))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(numbers.Min());
                }
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}