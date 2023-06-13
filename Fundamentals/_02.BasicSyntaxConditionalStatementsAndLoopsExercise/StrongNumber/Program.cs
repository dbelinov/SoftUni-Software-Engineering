using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int editableNumber = number;

            int currentDigit = 0;
            int factorial = 1;
            int finalFactorial = 0;
            while (editableNumber > 0)
            {
                currentDigit = editableNumber % 10;
                editableNumber = editableNumber / 10;


                for (int i = 1; i <= currentDigit; i++)
                {
                    factorial *= i;
                }

                finalFactorial += factorial;
                factorial = 1;
            }

            if (finalFactorial == number)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }

        }
    }
}