using System;
using System.Numerics;

namespace _02.LettersCombinations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstLetter = char.Parse(Console.ReadLine());
            char finalLetter = char.Parse(Console.ReadLine());
            char skippedLetter = char.Parse(Console.ReadLine());

            //char nextLetter = (char)(((int)firstLetter) + 1);
            //Console.WriteLine(nextLetter);

            int counter = 0;

            for (char i = firstLetter; i <= finalLetter; i++)
            {
                if (i != skippedLetter)
                {
                    for (char j = firstLetter; j <= finalLetter; j++)
                    {
                        if (j != skippedLetter)
                        {
                            for (char k = firstLetter; k <= finalLetter; k++)
                            {
                                if (k != skippedLetter)
                                {
                                    Console.Write($"{i}{j}{k} ");
                                    counter++;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}
