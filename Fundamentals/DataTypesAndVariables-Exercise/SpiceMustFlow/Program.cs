using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main(string[] args)
        {
            int yield = int.Parse(Console.ReadLine());

            int spices = 0;
            int days = 0;
            while (yield >= 100)
            {
                spices += yield;
                spices -= 26;
                yield -= 10;
                days++;
            }

            spices -= 26;

            if (spices < 0)
            {
                spices = 0;
            }

            Console.WriteLine(days);
            Console.WriteLine(spices);
        }
    }
}