using System;

namespace _08.FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInt = int.Parse(Console.ReadLine());
            int secondInt = int.Parse(Console.ReadLine());

            double factorialOfFirstInt = GetFactorialOfNumber(firstInt);
            double factorialOfSecondInt = GetFactorialOfNumber(secondInt);
            PrintDivisionOfFactorials(factorialOfFirstInt, factorialOfSecondInt);
        }
        
        private static double GetFactorialOfNumber(int number)
        {
            double result = number;
            for (int i = number - 1; i > 0; i--)
            {
                result *= i;
            }

            return result;
        }
        
        private static void PrintDivisionOfFactorials(double factorialOfFirstInt, double factorialOfSecondInt)
        {
            double division = factorialOfFirstInt / factorialOfSecondInt;
            Console.WriteLine($"{division:f2}");
        }
    }
}