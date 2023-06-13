using System;

namespace ExactSumOfRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberAmount = int.Parse(Console.ReadLine());

            decimal sum = 0m;
            for (int i = 1; i <= numberAmount; i++)
            {
                decimal number = decimal.Parse(Console.ReadLine());
                sum += number;
            }

            Console.WriteLine(sum);
        }
    }
}