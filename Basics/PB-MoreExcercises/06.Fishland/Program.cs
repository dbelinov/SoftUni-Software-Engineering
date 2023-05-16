using System;

namespace _06.Fishland
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double mackerelPrice = double.Parse(Console.ReadLine());
            double spratPrice = double.Parse(Console.ReadLine());
            double bonito = double.Parse(Console.ReadLine());
            double scad = double.Parse(Console.ReadLine());
            int mussels = int.Parse(Console.ReadLine());

            double bonitoPrice = 1.6 * mackerelPrice;
            double bonitoCost = bonito * bonitoPrice;
            double scadPrice = 1.8 * spratPrice;
            double scadCost = scad * scadPrice;
            double musselsPrice = 7.50;
            double musselsCost = mussels * musselsPrice;

            double finalPrice = bonitoCost + scadCost + musselsCost;

            Console.WriteLine($"{finalPrice:F2}");
        }
    }
}
