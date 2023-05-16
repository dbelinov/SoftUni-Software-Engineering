using System;

namespace BullsAndCowsTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int guessNumber = int.Parse(Console.ReadLine());
            int targetBulls = int.Parse(Console.ReadLine());
            int targetCows = int.Parse(Console.ReadLine());

            bool solutionFound = false;

            if(!solutionFound)
            {
                Console.WriteLine("No");
            }

            for (int digit1 = 1; digit1 <= 9; digit1++)
            {
                for (int digit2 = 1; digit2 <= 9; digit2++)
                {
                    for (int digit3 = 1; digit3 <= 9; digit3++)
                    {
                        for (int digit4 = 1; digit4 <= 9; digit4++)
                        {
                            int guessDigit1 = (guessNumber / 1000) % 10;
                            int guessDigit2 = (guessNumber / 100) % 10;
                            int guessDigit3 = (guessNumber / 10) % 10;
                            int guessDigit4 = guessNumber % 10;
                        }
                    }
                }
            }
        }
    }
}
