using System;

namespace _01.SignOfIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string type = TypeOfNumberCheck(number);

            Console.WriteLine($"The number {number} is {type}.");
        }

        private static string TypeOfNumberCheck(int number)
        {
            if (number < 0)
                return "negative";
            if (number > 0)
                return "positive";
            return "zero";
        }
    }
}