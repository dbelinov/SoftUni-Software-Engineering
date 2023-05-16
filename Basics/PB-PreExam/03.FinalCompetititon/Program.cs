using Microsoft.VisualBasic;
using System;

namespace _03.FinalCompetititon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int dancers = int.Parse(Console.ReadLine());
            double points = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            string place = Console.ReadLine();

            double wonMoney = 0;

            if (place == "Bulgaria")
            {
                wonMoney = points * dancers;
                
                if (season == "summer")
                {
                    wonMoney = 0.95 * wonMoney;
                }
                else if (season == "winter")
                {
                    wonMoney = 0.92 * wonMoney;
                }
            }
            else
            {
                double midCalc = dancers * points;
                wonMoney = 1.5 * midCalc;

                if (season == "summer")
                {
                    wonMoney = 0.9 * wonMoney;
                }
                else if (season == "winter")
                {
                    wonMoney = 0.85 * wonMoney;
                }
            }

            double charity = 0.75 * wonMoney;
            double finalMoney = wonMoney - charity;

            double moneyPerPerson = finalMoney / dancers;

            Console.WriteLine($"Charity - {charity:f2}");
            Console.WriteLine($"Money per dancer - {moneyPerPerson:f2}");

        }
    }
}
