using System;

namespace _02.TriangleArea
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = Double.Parse(Console.ReadLine());
            double h = Double.Parse(Console.ReadLine());

            double area = a * h / 2;

            Console.WriteLine($"{area:F2}");
        }
    }
}
