using System;

namespace _05.Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            int quantity = int.Parse(Console.ReadLine());

            CalculateAndPrintPrice(product, quantity);
        }

        private static void CalculateAndPrintPrice(string product, int quantity)
        {
            double pricePerProduct = 0;
            switch (product)
            {
                case "coffee":
                    pricePerProduct = 1.50;
                    break;
                case "water":
                    pricePerProduct = 1.00;
                    break;
                case "coke":
                    pricePerProduct = 1.40;
                    break;
                case "snacks":
                    pricePerProduct = 2.00;
                    break;
            }

            Console.WriteLine($"{pricePerProduct * quantity:f2}");
        }
    }
}