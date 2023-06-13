using System;
using System.Collections.Generic;

namespace _06.MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            FindAndPrintMiddleCharacter(input);
        }

        private static void FindAndPrintMiddleCharacter(string input)
        {
            char[] inputAsChars = input.ToCharArray();
            for (int i = 0; i < inputAsChars.Length; i++)
            {
                if (inputAsChars.Length % 2 != 0)
                {
                    if (i == inputAsChars.Length / 2 + 1)
                    {
                        Console.Write(inputAsChars[i - 1]);
                    }
                }
                else
                {
                    if (i == inputAsChars.Length / 2 || i == inputAsChars.Length / 2 + 1)
                    {
                        Console.Write(inputAsChars[i - 1]);
                    }
                }
            }
        }
    }
}