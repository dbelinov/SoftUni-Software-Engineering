using System;

namespace _07.TrekkingMania
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Read all input
            int n = int.Parse(Console.ReadLine());
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;

            int totalCountOfPeople = 0;
            for(int i = 0; i < n; i++)
            {
                // 2. Read the number of people forming the current group
                int countOfPeople = int.Parse(Console.ReadLine());

                // 3. Distribute by categories 
                if (countOfPeople <= 5)
                {
                    p1 += countOfPeople;
                } 
                else if (countOfPeople <= 12)
                {
                    p2 += countOfPeople;
                }
                else if (countOfPeople <= 25)
                {
                    p3 += countOfPeople;
                }
                else if (countOfPeople <= 40)
                {
                    p4 += countOfPeople;
                }
                else
                {
                    p5 += countOfPeople;
                }

                totalCountOfPeople += countOfPeople;
            }

            // 4. Print output 
            Console.WriteLine($"{(double) p1/ totalCountOfPeople * 100:f2}%");
            Console.WriteLine($"{(double) p2/ totalCountOfPeople * 100:f2}%");
            Console.WriteLine($"{(double) p3/ totalCountOfPeople * 100:f2}%");
            Console.WriteLine($"{(double) p4/ totalCountOfPeople * 100:f2}%");
            Console.WriteLine($"{(double) p5/ totalCountOfPeople * 100:f2}%");
        }
    }
}
