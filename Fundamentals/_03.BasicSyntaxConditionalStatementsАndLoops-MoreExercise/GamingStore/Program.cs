using System;

namespace GamingStore
{
    class Program
    {
        static void Main(string[] args)
        {
            double balance = double.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            string game = "";
            double priceOfGame = 0;
            double spentMoney = 0;
            while (input != "Game Time")
            {
                switch (input)
                {
                    case "OutFall 4":
                        game = "OutFall 4";
                        priceOfGame = 39.99;
                        break;
                    case "CS: OG":
                        game = "CS: OG";
                        priceOfGame = 15.99;
                        break;
                    case "Zplinter Zell":
                        game = "Zplinter Zell";
                        priceOfGame = 19.99;
                        break;
                    case "Honored 2":
                        game = "Honored 2";
                        priceOfGame = 59.99;
                        break;
                    case "RoverWatch":
                        game = "RoverWatch";
                        priceOfGame = 29.99;
                        break;
                    case "RoverWatch Origins Edition":
                        game = "RoverWatch Origins Edition";
                        priceOfGame = 39.99;
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }

                if (priceOfGame <= balance && game != "")
                {
                    Console.WriteLine($"Bought {game}");
                    balance -= priceOfGame;
                    spentMoney += priceOfGame;
                }
                else if (priceOfGame > balance)
                {
                    Console.WriteLine($"Too Expensive");
                }

                if (balance == 0)
                {
                    Console.WriteLine("Out of money");
                    return;
                }
                
                game = "";
                priceOfGame = 0;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total spent: ${spentMoney:f2}. Remaining: ${balance:f2}");
        }
    }
}