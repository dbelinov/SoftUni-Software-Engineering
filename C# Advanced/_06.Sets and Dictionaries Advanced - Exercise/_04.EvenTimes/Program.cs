using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.EvenTimes
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> nums = new Dictionary<int, int>();
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                int number = int.Parse(Console.ReadLine());

                if (!nums.ContainsKey(number))
                {
                    nums.Add(number, 0);
                }

                nums[number]++;
            }
            
            Console.WriteLine(nums.First(x => x.Value % 2 == 0).Key);
        }
    }
}