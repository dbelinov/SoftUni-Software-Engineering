using System;

namespace _06.Cake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int cakeLeft = width * length;
            int taken = 0;

            while (cakeLeft >= 0)
            {
                string input = Console.ReadLine();

                if (input == "STOP") break;

                int pieces = int.Parse(input);
                taken += pieces;
                cakeLeft -= pieces;
            }

            if (cakeLeft >= 0)
            {
                Console.WriteLine($"{cakeLeft} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(cakeLeft)} pieces more.");
            }
        }
    }
}
