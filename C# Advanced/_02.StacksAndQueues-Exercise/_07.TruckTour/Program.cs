﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TruckTour
{
    class Program
    {
        static void Main(string[] args)
        {
            int petrolPumps = int.Parse(Console.ReadLine());
            Queue<int[]> pumps = new Queue<int[]>();
            for (int i = 0; i < petrolPumps; i++)
            {
                pumps.Enqueue(Console.ReadLine().Split().Select(int.Parse).ToArray());
            }

            int bestRoute = 0;

            while (true)
            {
                int totalPetrol = 0;

                foreach (int[] pump in pumps)
                {
                    totalPetrol += pump[0];
                    int currentDistance = pump[1];

                    if (totalPetrol - currentDistance < 0)
                    {
                        totalPetrol = 0;
                        break;
                    }
                    else
                    {
                        totalPetrol -= currentDistance;
                    }
                }

                if (totalPetrol > 0)
                {
                    break;
                }

                bestRoute++;
                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(bestRoute);
        }
    }
}