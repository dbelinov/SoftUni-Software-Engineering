using System;

namespace _03.SumNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            int sum = 0;

            while (sum < number)
            {
                int current = int.Parse(Console.ReadLine());
                sum += current;
            }

            Console.WriteLine(sum);
        }
    }
}
