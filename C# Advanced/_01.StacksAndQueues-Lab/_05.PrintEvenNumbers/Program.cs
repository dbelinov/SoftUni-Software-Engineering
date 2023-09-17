using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.PrintEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> numbers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> evenNums = new Queue<int>();

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNums.Enqueue(number);
                }
            }

            Console.WriteLine(string.Join(", ", evenNums));
        }
    }
}