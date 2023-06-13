using System;
using System.Threading.Channels;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double moneyCount = 0;
            double price = 0;

            while (input != "Start")
            {
                double coin = double.Parse(input);
                if (coin == 0.1 || coin == 0.2 || coin == 0.5 || coin == 1 || coin == 2)
                {
                    moneyCount += coin;
                }
                else
                {
                    Console.WriteLine($"Cannot accept {coin}");
                }
                
                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "End")
            {
                switch (input)
                {
                    case "Nuts":
                        price = 2.0;
                        if (moneyCount >= price)
                        {
                            moneyCount -= price;
                            Console.WriteLine("Purchased nuts");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Water":
                        price = 0.7;
                        if (moneyCount >= price)
                        {
                            moneyCount -= price;
                            Console.WriteLine("Purchased water");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }
                        break;
                    case "Crisps":
                        price = 1.5;
                        if (moneyCount >= price)
                        {
                            moneyCount -= price;
                            Console.WriteLine("Purchased crisps");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }

                        break;
                    case "Soda":
                        price = 0.8;
                        if (moneyCount >= price)
                        {
                            moneyCount -= price;
                            Console.WriteLine("Purchased soda");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }

                        break;
                    case "Coke":
                        price = 1.0;
                        if (moneyCount >= price)
                        {
                            moneyCount -= price;
                            Console.WriteLine("Purchased coke");
                        }
                        else
                        {
                            Console.WriteLine("Sorry, not enough money");
                        }

                        break;
                    default: Console.WriteLine("Invalid product");
                        break;
                }
                
                input = Console.ReadLine();
            }

            Console.WriteLine($"Change: {moneyCount:f2}");
        }
    }
}