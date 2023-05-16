using System;

namespace SecretDoorLock
{
    class Program
    {
        static void Main(string[] args)
        {
            int upperHundreds = int.Parse(Console.ReadLine());
            int upperTens = int.Parse(Console.ReadLine());
            int upperOnes = int.Parse(Console.ReadLine());

            bool isPrime = false;
            
            for (int hundreds = 1; hundreds <= upperHundreds; hundreds++)
            {
                if (hundreds % 2 == 0)
                {
                    for (int tens = 0; tens <= upperTens; tens++)
                    {
                        if (tens == 2 || tens == 3 || tens == 5 || tens == 7)
                        {
                            for (int ones = 1; ones <= upperOnes; ones++)
                            {
                                if (ones % 2 == 0)
                                {
                                    Console.WriteLine($"{hundreds} {tens} {ones}");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}