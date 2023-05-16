using System;

namespace _051.TrainingLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double widthCm = width * 100;
            double heightCm = height * 100;

            int lines = (int)widthCm / 120;
            int placesPerLine = ((int)heightCm - 100) / 70;
            int allPlaces = lines * placesPerLine - 3;

            Console.WriteLine(allPlaces);
        }
    }
}
