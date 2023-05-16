using System;

namespace _08.PetShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dogFood = int.Parse(Console.ReadLine());
            int catFood = int.Parse(Console.ReadLine());

            double priceDog = dogFood * 2.50;
            int priceCat = catFood * 4;
            double priceAll = priceDog + priceCat;

            Console.WriteLine($"{priceAll} lv.");
        }
    }
}
