using System;

namespace Oscars_Ceremony
{
    class Program
    {
        static void Main(string[] args)
        {
            int rent = int.Parse(Console.ReadLine());

            double priceStatuets = 0.7 * rent;
            double priceKethering = 0.85 * priceStatuets;
            double priceSound = 0.5 * priceKethering;

            double price = rent + priceStatuets + priceKethering + priceSound;

            Console.WriteLine($"{price:f2}");
        }
    }
}