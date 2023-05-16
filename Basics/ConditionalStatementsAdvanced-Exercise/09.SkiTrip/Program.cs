using System;
using System.Xml;

namespace _09.SkiTrip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            string roomType = Console.ReadLine();
            string review = Console.ReadLine();

            int nights = days - 1;
            double cost = 0;
            double discount = 0;

            if (roomType == "room for one person")
            {
                discount = nights * 18;
            }
            else if (roomType == "apartment")
            {
                cost = nights * 25;
                if (nights < 10)
                {
                    discount = 0.7 * cost;
                }
                else if (nights >=10 && nights <= 15)
                {
                    discount = 0.65 * cost;
                }
                else if (nights >15)
                {
                    discount = 0.5 * cost;
                }
            }
            else if (roomType == "president apartment")
            {
                cost = nights * 35;
                if (nights < 10)
                {
                    discount = 0.9 * cost;
                }
                else if (nights >=10 && nights <= 15)
                {
                    discount = 0.85 * cost;
                }
                else if (nights > 15)
                {
                    discount = 0.8 * cost;
                }
            }

            if (review == "positive")
            {
                discount = 1.25 * discount;
                Console.WriteLine($"{discount:F2}");
            }
            else if (review == "negative")
            {
                cost = 0.9 * discount;
                Console.WriteLine($"{cost:F2}");
            }

            
        }
    }
}
