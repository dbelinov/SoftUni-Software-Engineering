using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int capacity = int.Parse(Console.ReadLine());

            int currentRack = 0;
            int racks = 1;
            while (clothes.Count > 0)
            {
                int currentClothing = clothes.Peek();
                if (currentRack + currentClothing <= capacity)
                {
                    currentRack += clothes.Pop();
                }
                else
                {
                    racks++;
                    currentRack = 0;
                }
            }

            Console.WriteLine(racks);
        }
    }
}