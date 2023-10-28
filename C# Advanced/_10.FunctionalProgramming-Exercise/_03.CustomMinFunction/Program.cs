using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Channels;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Func<HashSet<int>, int> returnMinNum = ReturnMinNum;

            int ReturnMinNum(HashSet<int> nums)
            {
                int minNum = int.MaxValue;
                foreach (var num in nums)
                {
                    if (num < minNum)
                    {
                        minNum = num;
                    }
                }

                return minNum;
            }
            
            HashSet<int> numbers = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToHashSet();

            Console.WriteLine(returnMinNum(numbers));
        }
    }
}