using System;

namespace _02.RadiantsToDegrees
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double radiants = double.Parse(Console.ReadLine());
            double degrees = radiants * 180 / Math.PI;
            Console.WriteLine(degrees);
        }
    }
}
