using System;

namespace ConvertMetersToKilometers
{
    class Program
    {
        static void Main(string[] args)
        {
            float meters = float.Parse(Console.ReadLine());

            float kilometers = meters / 1000;

            Console.WriteLine($"{kilometers:f2}");
        }
    }
}