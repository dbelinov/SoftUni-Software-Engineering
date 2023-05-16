using System;

namespace _02.EqualSumsEvenOddPosition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());

            int finalNumber = 0;

            for (int i = start; i <= end; i++)
            {
                int number = i;
                int evenSum = 0, oddSum = 0, digitPosition = 1;

                while (number != 0)
                {
                    finalNumber = number % 10;

                    if (digitPosition % 2 == 0)
                    {
                        evenSum += finalNumber;
                    }
                    else
                    {
                        oddSum += finalNumber;
                    }
                    digitPosition++;
                    number = number / 10;
                }

                if(oddSum == evenSum)
                Console.Write($"{i} ");
            }
        }
    }
}
