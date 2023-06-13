using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> first = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> second = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> finalList = new List<int>();

            int iterations = Math.Max(first.Count, second.Count);
            for (int i = 0; i < iterations; i++)
            {
                if (i < first.Count)
                    finalList.Add(first[i]);
                if (i < second.Count)
                    finalList.Add(second[i]);
            }

            Console.WriteLine(string.Join(' ', finalList));
        }
    }
}