using System;

namespace _07.FoodDelivery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chickenMenu = int.Parse(Console.ReadLine());
            int fishMenu = int.Parse(Console.ReadLine());
            int veganMenu = int.Parse(Console.ReadLine());

            double priceFood = chickenMenu * 10.35 + fishMenu * 12.40 + veganMenu * 8.15;
            double priceDesert = priceFood * 0.2;
            double finalPrice = priceFood + priceDesert + 2.50;

            Console.WriteLine(finalPrice);
        }
    }
}
