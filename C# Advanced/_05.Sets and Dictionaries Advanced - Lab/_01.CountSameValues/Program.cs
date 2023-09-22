using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.CountSameValues
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console.ReadLine().Split().Select(double.Parse).ToArray();

            Dictionary<double, int> counts = new Dictionary<double, int>();

            for (int i = 0; i < nums.Length; i++)
            {
                if (!counts.ContainsKey(nums[i]))
                {
                    counts.Add(nums[i], 0);
                }

                counts[nums[i]]++;
            }

            foreach (var count in counts)
            {
                Console.WriteLine($"{count.Key} - {count.Value} times");
            }
        }
    }
}