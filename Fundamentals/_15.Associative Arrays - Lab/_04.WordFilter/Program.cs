using System;
using System.Linq;

namespace _04.WordFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();
            string[] filteredWords = words.Where(words => words.Length % 2 == 0).ToArray();
            foreach (var word in filteredWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}