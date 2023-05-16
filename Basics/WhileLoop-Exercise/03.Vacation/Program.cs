using System;

namespace _03.Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double moneyNeeded = double.Parse(Console.ReadLine());
            double availableMoney = double.Parse(Console.ReadLine());

            int days = 0;
            int daysSpent = 0;

            while (availableMoney < moneyNeeded && daysSpent < 5)
            {
                string typeOfActivity = Console.ReadLine();
                double moneyChange = double.Parse(Console.ReadLine());
                days++;

                if (typeOfActivity == "spend")
                {
                    if (moneyChange > availableMoney)
                    {
                        availableMoney = 0;
                    }
                    else
                    {
                        availableMoney -= moneyChange;
                    }
                    daysSpent++;
                }
                else
                {
                    availableMoney += moneyChange;
                    daysSpent = 0;
                    if (availableMoney >= moneyNeeded) break;
                }
            }

            if (daysSpent < 5)
            {
                Console.WriteLine($"You saved the money for {days} days.");
            }
            else
            {
                Console.WriteLine("You can't save the money.");
                Console.WriteLine(days);
            }
            
        }
    }
}
