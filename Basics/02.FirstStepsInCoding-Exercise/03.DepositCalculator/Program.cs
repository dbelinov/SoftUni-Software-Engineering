using System;

namespace _03.DepositCalculator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double depSum = double.Parse(Console.ReadLine());
            int srok = int.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double sum = depSum + srok * ((depSum * percent * 0.01) / 12);

            Console.WriteLine(sum);
        }
    }
}
