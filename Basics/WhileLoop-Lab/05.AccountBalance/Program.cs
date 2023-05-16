using System;

namespace _05.AccountBalance
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            double starting = 0;

            while (input != "NoMoreMoney")
            {
                double money = double.Parse(input);
                
                if(money < 0)
                {
                    Console.WriteLine("Invalid operation!");
                    break;
                }

                starting += money;

                Console.WriteLine($"Increase: {money:f2}");

                input = Console.ReadLine();
            }
            Console.WriteLine($"Total: {starting:f2}");
        }
    }
}
