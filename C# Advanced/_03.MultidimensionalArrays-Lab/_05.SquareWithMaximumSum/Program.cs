using System;
using System.Linq;
/*
3, 6
7, 1, 3, 3, 2, 1 
1, 3, 9, 8, 5, 6 
4, 6, 7, 9, 1, 0
*/

namespace _05.SquareWithMaximumSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] rowValues = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            int biggestSum = int.MinValue;
            int biggestSumIndexRow = -1;
            int biggestSumIndexCol = -1;
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    int sum = 0;
                    if (col + 1 < cols && row + 1 < rows)
                    {
                        sum += matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    }
                    if (sum > biggestSum)
                    {
                        biggestSum = sum;
                        biggestSumIndexRow = row;
                        biggestSumIndexCol = col;
                    }
                }
            }

            Console.WriteLine($"{matrix[biggestSumIndexRow, biggestSumIndexCol]} {matrix[biggestSumIndexRow, biggestSumIndexCol + 1]}");
            Console.WriteLine($"{matrix[biggestSumIndexRow + 1, biggestSumIndexCol]} {matrix[biggestSumIndexRow + 1 , biggestSumIndexCol + 1]}");
            Console.WriteLine(biggestSum);
        }
    }
}