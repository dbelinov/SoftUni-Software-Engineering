using System;

namespace _01.PipesInPool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int V = int.Parse(Console.ReadLine());
            int P1 = int.Parse(Console.ReadLine());
            int P2 = int.Parse(Console.ReadLine());
            double N = double.Parse(Console.ReadLine());

            double pipe1Filled = P1 * N;
            double pipe2Filled = P2 * N;
            double water = pipe1Filled + pipe2Filled;
            double percentWater = water / V * 100;
            double percentPipe1 = pipe1Filled / water * 100;
            double percentPipe2 = pipe2Filled / water * 100;
            

            if(water <= V)
            {

                Console.WriteLine($"The pool is {percentWater:F2}% full. Pipe 1: {percentPipe1:F2}%. Pipe 2: {percentPipe2:F2}%.");
            }
            else
            {
                double overflow = water - V;
                Console.WriteLine($"For {N} hours the pool overflows with {overflow:F2} liters.");
            }
        }
    }
}
