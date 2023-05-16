using System;

namespace _03.NewHome
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string flower = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double totalCosts = 0;

            if(flower == "Roses")
            {
                totalCosts = 5 * amount;

                if (amount > 80)
                {
                    totalCosts = 0.9 * totalCosts;
                }
            }
            else if (flower == "Dahlias")
            {
                totalCosts = 3.8 * amount;

                if(amount > 90)
                {
                    totalCosts = 0.85 * totalCosts;
                }
            }
            else if (flower == "Tulips")
            {
                totalCosts = 2.8 * amount;

                if(amount > 80)
                {
                    totalCosts = 0.85 * totalCosts;
                }
            }
            else if (flower == "Narcissus")
            {
                totalCosts = 3 * amount;
                if (amount < 120)
                {
                    totalCosts = 1.15 * totalCosts;
                }
            }
            else if (flower == "Gladiolus")
            {
                totalCosts = 2.5 * amount;
                if (amount < 80)
                {
                    totalCosts = 1.2 * totalCosts;
                }
            }

            if(budget >= totalCosts)
            {
                double remaining = budget - totalCosts;
                Console.WriteLine($"Hey, you have a great garden with {amount} {flower} and {remaining:F2} leva left.");
            }
            else
            {
                double needed = totalCosts - budget;
                Console.WriteLine($"Not enough money, you need {needed:F2} leva more.");
            }


        }
    }
}
