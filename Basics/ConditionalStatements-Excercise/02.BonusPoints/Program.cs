using System;

namespace _02.BonusPoints
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            double bonus = 0.0;
            double bonus2 = 0.0;

            if (number <= 100)
                bonus = 5;
            else if (number > 100 && number < 1000)
                bonus = 0.2 * number;
            else if (number >= 1000)
                bonus = 0.1 * number;

            if (number % 2 == 0)
                bonus2 = 1;
            else if (number % 5 == 0 && number % 2 != 0)
                bonus2 = 2;

            double allBonus = bonus + bonus2;
            double finalNumber = number + allBonus;

            Console.WriteLine(allBonus);
            Console.WriteLine(finalNumber);
        }
    }
}
