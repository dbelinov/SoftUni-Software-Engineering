using System;
using System.Collections.Generic;

namespace _01.ReverseAString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Stack<char> characters = new Stack<char>(input);

            while (characters.Count > 0)
            {
                Console.Write(characters.Pop());
            }
        }
    }
}