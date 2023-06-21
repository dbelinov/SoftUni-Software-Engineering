using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            int specialNumber = int.Parse(Console.ReadLine());
            int power = int.Parse(Console.ReadLine());

            for (int i = 0; i < sequence.Count; i++)
            {
                if (sequence[i] == specialNumber)
                {
                    for (int j = 0; j < power; j++)
                    {
                        
                    }
                }
            }
        }
    }
}