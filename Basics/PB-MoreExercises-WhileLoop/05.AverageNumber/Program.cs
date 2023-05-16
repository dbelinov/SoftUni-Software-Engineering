using System;

namespace _05.AverageNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int repeatTimes = int.Parse(Console.ReadLine());
            double sum = 0;

            for (int i = 0; i < repeatTimes; i++)
            {
                int number = int.Parse(Console.ReadLine());
                sum += number;
            }

            double averageNum = sum / repeatTimes;

            Console.WriteLine($"{averageNum:f2}");
        }
    }
}
