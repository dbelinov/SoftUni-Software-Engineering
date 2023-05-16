using System;

namespace _01.MatchTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double budget = double.Parse(Console.ReadLine());
            string category = Console.ReadLine();
            int people = int.Parse(Console.ReadLine());

            double costTransport = 0;

            if (people >= 1 && people <= 4)
            {
                costTransport = 0.75 * budget;
            }
            else if (people >= 5 && people <= 9)
            {
                costTransport = 0.6 * budget;
            }
            else if (people >= 10 && people <= 24)
            {
                costTransport = 0.5 * budget;
            }
            else if (people >= 25 && people <= 49)
            {
                costTransport = 0.4 * budget;
            }
            else if (people >= 50)
            {
                costTransport = 0.25 * budget;
            }

            double moneyLeft = budget - costTransport;
            double ticketCost = 0;

            if (category == "VIP")
            {
                ticketCost = people * 499.99;

                if(moneyLeft >= ticketCost)
                {
                    double remainingMoney = moneyLeft - ticketCost;
                    Console.WriteLine($"Yes! You have {remainingMoney:F2} leva left.");
                }
                else
                {
                    double neededMoney = ticketCost - moneyLeft;
                    Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                }
            }
            else if (category == "Normal")
            {
                ticketCost = people * 249.99;

                if (moneyLeft >= ticketCost)
                {
                    double remainingMoney = moneyLeft - ticketCost;
                    Console.WriteLine($"Yes! You have {remainingMoney:F2} leva left.");
                }
                else
                {
                    double neededMoney = ticketCost - moneyLeft;
                    Console.WriteLine($"Not enough money! You need {neededMoney:F2} leva.");
                }
            }
        }
    }
}
