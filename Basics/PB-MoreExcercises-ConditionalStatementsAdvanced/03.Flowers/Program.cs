using System;

namespace _03.Flowers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int chrysanthemums = int.Parse(Console.ReadLine());
            int roses = int.Parse(Console.ReadLine());
            int dandelions = int.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string holiday = Console.ReadLine(); //Y or N

            double chrysanthemumsCost = 0;
            double rosesCost = 0;
            double dandelionsCost = 0;
            double flowerAmount = chrysanthemums + roses + dandelions;

            if(season == "Spring" || season == "Summer")
            {
                chrysanthemumsCost = chrysanthemums * 2;
                rosesCost = roses * 4.10;
                dandelionsCost = dandelions * 2.50;
            }
            else if (season == "Autumn" || season == "Winter")
            {
                chrysanthemumsCost = chrysanthemums * 3.75;
                rosesCost = roses * 4.50;
                dandelionsCost = dandelions * 4.15;
            }

            double price = chrysanthemumsCost + rosesCost + dandelionsCost;
            bool discount1 = season == "Spring" && dandelions > 7;
            bool discount2 = season == "Winter" && roses >= 10;


            if (holiday == "Y")
            {
                price = 1.15 * price;
            }

            if (discount1)
            { 
                if (flowerAmount > 20)
                {
                    price = 0.95 * price;
                    price = 0.8 * price;
                }
                else
                {
                    price = 0.95 * price;
                }
            }
            else if (discount2)
            {
                if (flowerAmount > 20)
                {
                    price = 0.9 * price;
                    price = 0.8 * price;
                }
                else
                {
                    price = 0.9 * price;
                }
            }

            if (flowerAmount > 20 && !discount1 && !discount2)
            {
                price = 0.8 * price;
            }

            double finalPrice = price + 2;

            Console.WriteLine($"{finalPrice:F2}");
        }
    }
}
