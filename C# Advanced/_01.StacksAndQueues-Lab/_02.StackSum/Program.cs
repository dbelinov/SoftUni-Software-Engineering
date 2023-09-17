using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.StackSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> nums = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            string input;
            while ((input = Console.ReadLine().ToLower()) != "end")
            {
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "add":
                        int num1 = int.Parse(tokens[1]);
                        int num2 = int.Parse(tokens[2]);
                        nums.Push(num1);
                        nums.Push(num2);
                        break;
                    case "remove":
                        int amount = int.Parse(tokens[1]);
                        if (amount <= nums.Count)
                        {
                            for (int i = 0; i < amount; i++)
                            {
                                nums.Pop();
                            }
                        }
                        break;
                }
            }

            int sum = 0;
            foreach (int num in nums)
            {
                sum += num;
            }

            Console.WriteLine($"Sum: {sum}");
        }
    }
}