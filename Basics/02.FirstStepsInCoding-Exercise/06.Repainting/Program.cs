using System;
using System.Diagnostics.CodeAnalysis;

namespace _06.Repainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int nylon = int.Parse(Console.ReadLine());
            int paint = int.Parse(Console.ReadLine());
            int mixer = int.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());

            double sumNylon = (nylon + 2) * 1.50;
            double sumPaint = (paint + 0.1 * paint) * 14.50;
            double sumMixer = mixer * 5;

            double price = sumNylon + sumPaint + sumMixer + 0.40;
            double sumWorkers = (price * 0.3) * hours;
            double finalPrice = price + sumWorkers;

            Console.WriteLine(finalPrice);
        }
    }
}
