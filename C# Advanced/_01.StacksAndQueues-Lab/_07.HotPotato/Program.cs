using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.HotPotato
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> players = new Queue<string>(Console.ReadLine().Split());
            int n = int.Parse(Console.ReadLine());

            int counter = 0;

            while (players.Count > 1)
            {
                counter++;
                string currentChild = players.Dequeue();
                if (counter == n)
                {
                    Console.WriteLine($"Removed {currentChild}");
                    counter = 0;
                }
                else
                {
                    players.Enqueue(currentChild);
                }
            }

            Console.WriteLine($"Last is {players.Peek()}");
        }
    }
}