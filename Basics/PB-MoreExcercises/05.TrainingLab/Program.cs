using System;

namespace _05.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double height = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());

            double widthCm = width * 100;
            double heightCm = height * 100;

            double totalWidth = (widthCm - 100) / 70;
            double totalHeight = heightCm / 120;
            double totalWorkspaces = (totalWidth * totalHeight) - 3;

            Console.WriteLine(totalWorkspaces);
        }
    }
}
