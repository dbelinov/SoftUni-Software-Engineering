using System;
using System.Diagnostics.CodeAnalysis;

namespace _04.SmartLily
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Read all input
            int age = int.Parse(Console.ReadLine());
            double washerPrice = double.Parse(Console.ReadLine());
            int toyPrice = int.Parse(Console.ReadLine());

            // 2. Use a variable to sum all saved money
            // - if even birthday - the gift is money, her brother will take 1 lev
            // - if odd birthday - the gift is a toy that is sold for P levs.
            int savedMoney = 0;
            int giftedMoney = 10;
            for (int i = 1; i <= age; i++)
            {
                if (i % 2 != 0)
                {
                    savedMoney += toyPrice;
                }
                else
                {
                    savedMoney += giftedMoney - 1;
                    giftedMoney += 10;
                }
            }

            //3.Print output
            if(savedMoney >= washerPrice)
            {
                double diff = Math.Abs(washerPrice - savedMoney);
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
            {
                double diff = Math.Abs(savedMoney - washerPrice);
                Console.WriteLine($"No! {diff:f2}");
            }

        }
    }
}
