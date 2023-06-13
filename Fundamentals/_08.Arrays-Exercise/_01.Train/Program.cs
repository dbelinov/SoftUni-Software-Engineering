using System;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] peoplePerWagon = new int[n];

            int sum = 0;
            for (int i = 0; i < peoplePerWagon.Length; i++)
            {
                peoplePerWagon[i] = int.Parse(Console.ReadLine());
                sum += peoplePerWagon[i];
            }

            for (int i = 0; i < peoplePerWagon.Length; i++)
            {
                Console.Write($"{peoplePerWagon[i]} ");
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}