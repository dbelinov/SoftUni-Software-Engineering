using System;

namespace _01.GuinneaPig
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal foodInKilos = decimal.Parse(Console.ReadLine());
            decimal hayInKilos = decimal.Parse(Console.ReadLine());
            decimal coverInKilos = decimal.Parse(Console.ReadLine());
            decimal weightInKilos = decimal.Parse(Console.ReadLine());

            int days = 0;
            for (int i = 1; i <= 30; i++)
            {

                foodInKilos -= 0.3m;
                
                if (i % 2 == 0)
                {
                    hayInKilos -= 0.05m * foodInKilos;
                }

                if (i % 3 == 0)
                {
                    coverInKilos -= (weightInKilos / 3);
                }

                if(foodInKilos <= 0 || hayInKilos <= 0 || coverInKilos <= 0)
                    break;
                
                days++;
            }

            if (days == 30) 
            {
                Console.WriteLine($"Everything is fine! Puppy is happy! Food: {foodInKilos:f2}, Hay: {hayInKilos:f2}, Cover: {coverInKilos:f2}.");
            }
            else
            {
                Console.WriteLine("Merry must go to the pet store!");
            }
        }
    }
}