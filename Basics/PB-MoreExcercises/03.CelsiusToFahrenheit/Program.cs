using System;

namespace _03.CelsiusToFahrenheit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double Celsius = double.Parse(Console.ReadLine());
            double Fahrenheit = Celsius * 9 / 5 + 32;

            Console.WriteLine($"{Fahrenheit:F2}");
        }
    }
}
