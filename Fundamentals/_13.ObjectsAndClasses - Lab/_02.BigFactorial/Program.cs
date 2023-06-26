using System;
using System.Numerics;

namespace _02.BigFactorial
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong number = ulong.Parse(Console.ReadLine());
            BigInteger f = 1;

            for (ulong i = 1; i <= number; i++)
            {
                f *= i;
            }

            Console.WriteLine(f);
        }
    }
}