using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.SetsOfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            int[] sizes = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();
            for (int i = 0; i < sizes[0]; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }

            HashSet<int> mutualElements = set1.Intersect(set2).ToHashSet();

            Console.WriteLine(String.Join(" ", mutualElements));
        }
    }
}