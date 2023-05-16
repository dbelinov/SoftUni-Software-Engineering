using System;

namespace _09.FishTank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int length = int.Parse(Console.ReadLine());
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            double percentage = double.Parse(Console.ReadLine());

            int size = length * width * height;
            double sizeLitres = size * 0.001;
            double finalSize = sizeLitres * (1 - percentage * 0.01);

            Console.WriteLine(finalSize);
            
        }
    }
}
