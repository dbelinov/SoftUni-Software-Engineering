using System;

namespace _10.TopNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                if (SumOfDigitsDividableBy8(i) && HasOddDigit(i))
                {
                    Console.WriteLine(i);
                }   
            }
        }

        private static bool HasOddDigit(int i)
        {
            while (i > 0)
            {
                int currentDigit = i % 10;
                if (currentDigit % 2 != 0)
                    return true;
                i /= 10;
            }

            return false;
        }

        private static bool SumOfDigitsDividableBy8(int i)
        {
            int sum = 0;
            while (i > 0)
            {
                int currentDigit = i % 10;
                i /= 10;
                sum += currentDigit;
            }

            if (sum % 8 == 0)
                return true;
            return false;
        }
    }
}