using System;

namespace _08.MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            double baseNumber = double.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            Console.WriteLine(NumberRaisedInPower(baseNumber, power));
        }

        private static double NumberRaisedInPower(double baseNumber, int power)
        {
            return Math.Pow(baseNumber, power);
        }
    }
}