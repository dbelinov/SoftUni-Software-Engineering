using System;
using System.Collections.Specialized;
using System.Security.Cryptography.X509Certificates;

namespace _11.FruitShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string fruit = Console.ReadLine();
            string day = Console.ReadLine();
            double quantity = double.Parse(Console.ReadLine());

            double priceOfProduct = 0;

            bool workDays = day == "Monday" || day == "Tuesday" || day == "Wednesday" || day == "Thursday" || day == "Friday";
            bool weekends = day == "Saturday" || day == "Sunday";

            switch (fruit)
            {
                case "banana":
                    if(workDays)
                    {
                        priceOfProduct = 2.50;
                    }
                    else if (weekends)
                    {
                        priceOfProduct = 2.70;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                break;
                
                case "apple":
                    if(workDays)
                    {
                        priceOfProduct = 1.20;
                    }
                    else if (weekends)
                    {
                        priceOfProduct = 1.25;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                
                case "orange":
                    if(workDays)
                    {
                        priceOfProduct = 0.85;
                    }
                    else if (weekends)
                    {
                        priceOfProduct = 0.90;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                    break;
                
                case "grapefruit":
                    if(workDays)
                    {
                        priceOfProduct = 1.45;
                    }
                    else if (weekends)
                    {
                        priceOfProduct = 1.60;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                break;
                
                case "kiwi":
                    if(workDays)
                    {
                        priceOfProduct = 2.70;
                    }
                    else if (weekends)
                    {
                        priceOfProduct = 3.00;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                break;
                
                case "pineapple":
                    if(workDays)
                    {
                        priceOfProduct = 5.50;
                    }
                    else if (weekends)
                    {
                        priceOfProduct = 5.60;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                break;
                
                case "grapes":
                    if(workDays)
                    {
                        priceOfProduct = 3.85;
                    }
                    else if (weekends)
                    {
                        priceOfProduct = 4.20;
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                break;
                default:
                    Console.WriteLine("error");
                break;
            }

            if (priceOfProduct > 0)
            {
                double price = quantity * priceOfProduct;
                Console.WriteLine($"{price:F2}");
            }
        }
    }
}
