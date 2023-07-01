using System;
using System.Collections.Generic;

namespace _01.CountCharsInAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<char, int> letters = new Dictionary<char, int>();
            for (int i = 0; i < input.Length; i++)
            {
                char character = input[i];
                if (character == ' ')
                {
                    continue;
                }

                if (!letters.ContainsKey(character))
                {
                    letters.Add(character, 0);
                }

                letters[character]++;
            }

            foreach (var letter in letters)
            {
                Console.WriteLine($"{letter.Key} -> {letter.Value}");
            }
        }
    }
}