using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ranges = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> returnList = new List<int>();
            
            Func<int, string, bool> checker = Checker;

            bool Checker(int number, string condition)
            {
                if (condition == "even")
                {
                    return number % 2 == 0;
                } 
                return number % 2 != 0;
            }
            
            Func<int, int, List<int>> generateRange = (start, end) =>
            {
                List<int> range = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    range.Add(i);
                }

                return range;
            };

            List<int> nums = generateRange(ranges[0], ranges[1]);
            string condition = Console.ReadLine();

            foreach (var num in nums)
            {
                if (checker(num, condition))
                {
                    Console.Write($"{num} ");
                }
            }
        }
    }
}