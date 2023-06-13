using System;

namespace PoundsToDollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double brPounds = double.Parse(Console.ReadLine());

            double usd = brPounds * 1.31;

            Console.WriteLine($"{usd:f3}");
        }
    }
}