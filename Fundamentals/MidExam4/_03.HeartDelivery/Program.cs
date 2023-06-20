using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _03.HeartDelivery
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> neighbourhood = Console.ReadLine()
                .Split('@')
                .Select(int.Parse)
                .ToList();

            string input = "";

            int cupidPosition = 0;
            while ((input = Console.ReadLine()) != "Love!")
            {
                string [] arguments = input.Split().ToArray();
                int jumpingLength = int.Parse(arguments[1]);
                cupidPosition += jumpingLength;
                if (cupidPosition > neighbourhood.Count - 1)
                {
                    cupidPosition = 0;
                }

                neighbourhood[cupidPosition] -= 2;

                if (neighbourhood[cupidPosition] == 0)
                {
                    Console.WriteLine($"Place {cupidPosition} has Valentine's day.");
                }

                if (neighbourhood[cupidPosition] < 0)
                {
                    Console.WriteLine($"Place {cupidPosition} already had Valentine's day.");
                }
            }

            Console.WriteLine($"Cupid's last position was {cupidPosition}.");

            int failedHouses = 0;
            for (int i = 0; i < neighbourhood.Count; i++)
            {
                if (neighbourhood[i] > 0)
                {
                    failedHouses++;
                }
            }

            if (failedHouses == 0)
            {
                Console.WriteLine("Mission was successful.");
            }
            else
            {
                Console.WriteLine($"Cupid has failed {failedHouses} places.");
            }
        }
    }
}