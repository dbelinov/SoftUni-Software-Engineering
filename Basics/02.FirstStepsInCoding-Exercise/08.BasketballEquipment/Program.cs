
using System;

namespace _08.BasketballEquipment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int tax = int.Parse(Console.ReadLine());

            double priceShoes = 0.6 * tax;
            double priceClothes = 0.8 * priceShoes;
            double priceBall = 0.25 * priceClothes;
            double priceAccessories = 0.2 * priceBall;
            double finalPrice = tax + priceShoes + priceClothes + priceBall + priceAccessories;

            Console.WriteLine(finalPrice);
        }
    }
}
