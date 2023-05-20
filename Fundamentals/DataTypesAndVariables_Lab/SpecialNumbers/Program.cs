using System;

namespace SpecialNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            
            bool isSpecial = false;
            int sum = 0;
            for (int i = 1; i <= number; i++)
            {
                int num2 = i;
                while (num2 > 0)
                {
                    int currentDigit = num2 % 10;
                    num2 /= 10;
                    sum += currentDigit;
                }

                if (sum == 5 || sum == 7 || sum == 11) isSpecial = true;
                Console.WriteLine($"{i} -> {isSpecial}");
                isSpecial = false;
                sum = 0;
            }
        }
    }
}