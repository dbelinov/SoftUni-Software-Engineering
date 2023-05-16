using System;
using System.ComponentModel;

namespace _01.SumSeconds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int firstInput = int.Parse(Console.ReadLine());
            int secondInput = int.Parse(Console.ReadLine());
            int thirdInput = int.Parse(Console.ReadLine());

            int sum = firstInput+ secondInput + thirdInput;

            int minutes = sum / 60;
            int seconds = sum % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");
            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
