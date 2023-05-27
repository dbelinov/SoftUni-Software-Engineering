using System;
using System.Linq;

namespace _07.MaxSentenceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numbers = Console
                .ReadLine()
                .Split()
                .ToArray();

            int biggestCount = 0;
            string mostUsedElement = ""; 
            for (int i = 0; i < numbers.Length; i++)
            {
                int count = 1;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] == numbers[j])
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                    
                    if (count > biggestCount)
                    {
                        biggestCount = count;
                        mostUsedElement = numbers[j];
                    }
                }
            }

            for (int i = 0; i < biggestCount; i++)
            {
                Console.Write($"{mostUsedElement} ");
            }
        }
    }
}