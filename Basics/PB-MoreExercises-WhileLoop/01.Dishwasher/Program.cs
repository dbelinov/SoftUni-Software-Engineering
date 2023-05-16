using System;

namespace _01.Dishwasher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bottles = int.Parse(Console.ReadLine());
            const int detergentFillment = 750;
            const int needForDishes = 5;
            const int needForPots = 15;

            int detergentAmount = bottles * detergentFillment;
            int counterFills = 1;
            int washedDishes = 0;
            int washedPots = 0;

            while (detergentAmount >= 0)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                int thingsToWash = int.Parse(input);

                if(counterFills % 3 == 0)
                {
                    detergentAmount -= thingsToWash * needForPots;
                    washedPots += thingsToWash;
                }
                else
                {
                    detergentAmount -= thingsToWash * needForDishes;
                    washedDishes += thingsToWash;
                }
                counterFills++;
            }

            if(detergentAmount >= 0)
            {
                Console.WriteLine("Detergent was enough!");
                Console.WriteLine($"{washedDishes} dishes and {washedPots} pots were washed.");
                Console.WriteLine($"Leftover detergent {detergentAmount} ml.");
            }
            else
            {
                Console.WriteLine($"Not enough detergent, {Math.Abs(detergentAmount)} ml. more necessary!");
            }
        }
    }
}
