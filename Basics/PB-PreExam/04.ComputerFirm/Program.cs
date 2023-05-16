using System;

namespace _04.ComputerFirm
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double sells = 0;
            double allRating = 0;

            for (int i = 1; i <= n; i++)
            {
                int number = int.Parse(Console.ReadLine());

                int rating = number % 10;
                int possibleSells = number / 10;
                allRating += rating;

                switch (rating)
                {
                    case 2:
                        sells += 0;
                        break;
                    case 3: 
                        sells += 0.5 * possibleSells;
                        break;
                    case 4:
                        sells += 0.7 * possibleSells;
                        break;
                    case 5:
                        sells += 0.85 * possibleSells;
                        break;
                    case 6:
                        sells += possibleSells;
                        break;

                } 
            }

            Console.WriteLine($"{sells:f2}");
            Console.WriteLine($"{allRating / n:f2}");
        }
    }
}
