using System;

namespace _01.UniquePINs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int maxI1 = int.Parse(Console.ReadLine());
            int maxI2 = int.Parse(Console.ReadLine());
            int maxI3 = int.Parse(Console.ReadLine());

            for (int i1 = 2; i1 <= maxI1; i1 += 2) 
            { 
                for (int i2 = 2; i2 <= 7; i2++)
                {
                    if (i2 != 4 && i2 != 6 && i2 <= maxI2)
                    {
                        for (int i3 = 2; i3 <= maxI3; i3 += 2)
                        {
                            Console.WriteLine($"{i1} {i2} {i3}");
                        }
                    }
                }
            }
            
        }
    }
}
