using System;
using System.Linq;

namespace _01.DiagonalDifference
{
    class Program
    {
        static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];

            for (int row = 0; row < size; row++)
            {
                int[] values = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = values[col];
                }
            }
            
            int firstDiagonalSum = 0;
            int secondDiagonalSum = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (row == col)
                    {
                        firstDiagonalSum += matrix[row, col];
                    }

                    if (size - 1 - row == col)
                    {
                        secondDiagonalSum += matrix[row, col];
                    }
                }
            }

            Console.WriteLine(Math.Abs(firstDiagonalSum - secondDiagonalSum));
        }
    }
}