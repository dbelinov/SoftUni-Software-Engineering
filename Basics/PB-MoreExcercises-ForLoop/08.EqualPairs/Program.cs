using System;

namespace _08.EqualPairs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumPair = 0;
            int previousSum = 0;
            int value = 0;

            for (int i = 1; i <= n; i++)
            {
                int num1 = int.Parse(Console.ReadLine());
                int num2 = int.Parse(Console.ReadLine());

                sumPair = num1 + num2;

                if (sumPair == previousSum)
                {
                    value = sumPair; 
                }
                else
                {

                }

                if (n > 1)
                {
                    previousSum = sumPair;
                }

            }

            Console.WriteLine(value);
        }
    }
}
