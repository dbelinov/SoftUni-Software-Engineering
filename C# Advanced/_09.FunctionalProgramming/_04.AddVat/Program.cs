using System;
using System.Linq;

namespace _04.AddVat
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<double, double> adder = x => x * 1.2;

            double[] numbers = Console
                .ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .Select(adder)
                .ToArray();

            foreach (var number in numbers)
            {
                Console.WriteLine($"{number:f2}");
            }
        }
    }
}