using System;
using System.Linq;

namespace _09.KaminoFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            int lengthOfSequences = int.Parse(Console.ReadLine());
            string input = "";
            while ((input = Console.ReadLine()) != "Clone them!")
            {
                int[] dnaSequence = input.Split('!').Select(int.Parse).ToArray();
            }
        }
    }
}