using System;

namespace _08.CircleAreaAndPerimeter
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radius = double.Parse(Console.ReadLine());

            double area = Math.PI * Math.Pow(radius, 2);
            double perimetre = 2 * Math.PI * radius;

            Console.WriteLine($"{area:F2}");
            Console.WriteLine($"{perimetre:F2}");

        }
    }
}
