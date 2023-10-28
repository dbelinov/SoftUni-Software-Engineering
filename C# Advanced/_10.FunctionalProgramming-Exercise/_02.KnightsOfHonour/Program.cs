using System;
using System.Linq;

namespace _02.KnightsOfHonour
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> titleAdder = names =>
            {
                foreach (var name in names)
                {
                    Console.WriteLine($"Sir {name}");
                }
            };

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            titleAdder(names);
        }
    }
}