using System;
using System.Net.Sockets;

namespace _01.BackToThePast
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double inherited = double.Parse(Console.ReadLine());
            int finalYearToLive = int.Parse(Console.ReadLine());

            int age = 18;
            double moneySpent = 0;

            for(int i = 1800; i <= finalYearToLive; i++) //startingYear = 1800
            {
                if(i % 2 == 0)
                {
                    moneySpent += 12000;
                }
                else
                {
                    moneySpent += (12000 + 50 * age);
                }
                age++;
            }

            double diff = Math.Abs(inherited - moneySpent);

            if(moneySpent <= inherited)
            {
                Console.WriteLine($"Yes! He will live a carefree life and will have {diff:f2} dollars left.");
            }
            else
            {
                Console.WriteLine($"He will need {diff:f2} dollars to survive.");
            }
        }
    }
}
