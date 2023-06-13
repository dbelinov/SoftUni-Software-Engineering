using System;
using System.Linq;

namespace ReverseArrayOfStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console
                .ReadLine()
                .Split()
                .ToArray();

            for (int i = 0; i < input.Length / 2; i++)
            {
                string oldInput = input[i];
                input[i] = input[input.Length - 1 - i];
                input[input.Length - 1 - i] = oldInput;
            }

            Console.WriteLine(string.Join(' ', input));
        }
    }
}