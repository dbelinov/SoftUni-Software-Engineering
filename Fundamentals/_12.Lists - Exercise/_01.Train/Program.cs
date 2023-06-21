using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> passengers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
 
            int maxCapacity = int.Parse(Console.ReadLine());
 
            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
 
                if (tokens[0] == "Add")
                {
                    passengers.Add(int.Parse(tokens[1]));
                }
                else
                {
                    int incomingPassengers = int.Parse(tokens[0]);
                    for (int i = 0; i < passengers.Count; i++)
                    {
                        if (incomingPassengers + passengers[i] <= maxCapacity)
                        {
                            passengers[i] += incomingPassengers;
                            break;
                        }
                    }
                }
            }
 
            Console.WriteLine(string.Join(' ', passengers));
        }
    }
}