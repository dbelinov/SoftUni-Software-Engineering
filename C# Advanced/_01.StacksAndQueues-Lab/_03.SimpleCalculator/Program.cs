using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.SimpleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] expression = Console.ReadLine().Split();
            string[] reversedExpression = expression.Reverse().ToArray();
            Stack<string> stack = new Stack<string>(reversedExpression);
            int result = 0;
            result += int.Parse(stack.Pop());

            while (stack.Count > 0)
            {
                string operation = stack.Pop();
                int num = int.Parse(stack.Pop());

                if (operation == "-")
                {
                    result -= num;
                }
                else
                {
                    result += num;
                }
            }

            Console.WriteLine(result);
        }
    }
}