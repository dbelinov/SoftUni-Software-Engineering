using System;
using System.Linq;

/*
51 47 32 61 21
2
*/

namespace _04.ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rotations = int.Parse(Console.ReadLine());
            while (rotations > 0)
            {
                int[] medialArray = new int[numbers.Length];
                
                for (int i = 0; i < numbers.Length; i++)
                {
                    if (i < numbers.Length - 1)
                    {
                        medialArray[i] = numbers[i + 1];
                        medialArray[numbers.Length - 1] = numbers[0];
                    }
                }

                numbers = medialArray;
                rotations--;
            }

            Console.WriteLine(string.Join(' ', numbers));
        }
    }
}