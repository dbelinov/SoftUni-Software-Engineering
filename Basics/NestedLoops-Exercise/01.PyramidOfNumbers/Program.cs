using System;

namespace _01.PyramidOfNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int row = 1;
            int countOfWrittenNumbers = 0;

            for (int i = 1; i <= n; i++)
            {
                Console.Write($"{i} ");

                countOfWrittenNumbers++;

                if(countOfWrittenNumbers == row)
                {
                    Console.WriteLine();
                    countOfWrittenNumbers = 0;
                    row++;
                }
                
            }
        }
    }
}
