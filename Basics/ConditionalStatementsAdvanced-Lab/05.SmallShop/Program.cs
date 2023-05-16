using System;

namespace _05.SmallShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string product = Console.ReadLine();
            string city = Console.ReadLine();
            double amount = double.Parse(Console.ReadLine());

            double priceOfProduct = 0;

            switch (product)
            {
                case "coffee":
                    if (city == "Sofia")
                    {
                        priceOfProduct = 0.50;
                    }
                    else if (city == "Plovdiv")
                    {
                        priceOfProduct = 0.4;
                    }
                    else if (city == "Varna")
                    {
                        priceOfProduct = 0.45;
                    }
                    break;
                
                    case "water":
                    if (city == "Sofia")
                    {
                        priceOfProduct = 0.80;
                    }
                    else if (city == "Plovdiv")
                    {
                        priceOfProduct = 0.70;
                    }
                    else if (city == "Varna")
                    {
                        priceOfProduct = 0.70;
                    }
                    break;
                
                    case "beer":
                    if (city == "Sofia")
                    {
                        priceOfProduct = 1.20;
                    }
                    else if (city == "Plovdiv")
                    {
                        priceOfProduct = 1.15;
                    }
                    else if (city == "Varna")
                    {
                        priceOfProduct = 1.10;
                    }
                    break;
                
                    case "sweets":
                    if (city == "Sofia")
                    {
                        priceOfProduct = 1.45;
                    }
                    else if (city == "Plovdiv")
                    {
                        priceOfProduct = 1.30;
                    }
                    else if (city == "Varna")
                    {
                        priceOfProduct = 1.35;
                    }
                    break;
                
                    case "peanuts":
                    if (city == "Sofia")
                    {
                        priceOfProduct = 1.60;
                    }
                    else if (city == "Plovdiv")
                    {
                        priceOfProduct = 1.50;
                    }
                    else if (city == "Varna")
                    {
                        priceOfProduct = 1.55;
                    }
                    break;
            }

            double price = amount * priceOfProduct;
            Console.WriteLine(price);
        }
    }
}
