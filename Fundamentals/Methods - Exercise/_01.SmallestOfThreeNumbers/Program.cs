using System;

namespace _01.SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            int number3 = int.Parse(Console.ReadLine());

            Console.WriteLine(CheckForSmallestNumber(number1, number2, number3));
        }

        private static int CheckForSmallestNumber(int number1, int number2, int number3)
        {
            if (number1 < number2 && number1 < number3)
                return number1;
            if (number2 < number1 && number2 < number3)
                return number2;
            
            return number3;
        }
    }
}