using System;

namespace _04.Walking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int stepsSum = 0;
            int steps = 0;

            while (stepsSum < 10000)
            {
                string input = Console.ReadLine();
                if (input == "Going home")
                {
                    steps = int.Parse(Console.ReadLine());
                    stepsSum += steps;
                    break;
                }

                steps = int.Parse(input);
                stepsSum += steps;
            }

            if(stepsSum >= 10000)
            {
                Console.WriteLine("Goal reached! Good job!");
                Console.WriteLine($"{stepsSum - 10000} steps over the goal!");
            }
            else
            {
                Console.WriteLine($"{10000 - stepsSum} more steps to reach goal.");
            }
        }
    }
}
