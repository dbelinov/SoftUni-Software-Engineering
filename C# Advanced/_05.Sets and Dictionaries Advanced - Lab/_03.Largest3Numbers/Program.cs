using System;
using System.Linq;
using System.Net.Sockets;

namespace _03.Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] ints = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToArray();

            int[] sorted = new[] { 3 };
            if (ints.Length >= 3)
            {
                sorted = ints.OrderByDescending(x => x).Take(3).ToArray();
            }
            else
            {
                sorted = ints.OrderByDescending(x => x).ToArray();
            }

            Console.WriteLine(String.Join(" ", sorted));
        }
    }
}