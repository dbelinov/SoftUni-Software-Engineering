using System;
using System.Runtime.InteropServices;

namespace _05.Coins
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal cost = decimal.Parse(Console.ReadLine());
            int coinsCount = 0;

            while (cost > 0)
            {
                if (cost >= 2)
                {
                    cost -= 2;
                }
                else if (cost >= 1)
                {
                    cost -= 1;
                }
                else if (cost >= 0.50m)
                {
                    cost -= 0.50m;
                }
                else if (cost >= 0.20m)
                {
                    cost -= 0.20m;
                }
                else if (cost >= 0.10m)
                {
                    cost -= 0.10m;
                }
                else if (cost >= 0.05m)
                {
                    cost -= 0.05m;
                }
                else if (cost >= 0.02m)
                {
                    cost -= 0.02m;
                }
                else
                {
                    cost -= 0.01m;
                }
                coinsCount++;
            }

            Console.WriteLine(coinsCount);
        }
    }
}
