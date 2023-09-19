using System;
using System.Data;
using System.Linq;

namespace _04.SymbolInMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            bool charFound = false;

            for (int row = 0; row < size; row++)
            {
                char[] rowValues = Console.ReadLine().ToCharArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = rowValues[col];
                }
            }

            char elementToFind = char.Parse(Console.ReadLine());
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (matrix[row,col] == elementToFind)
                    {
                        Console.WriteLine($"({row}, {col})");
                        charFound = true;
                    }

                    if (charFound)
                    {
                        break;
                    }

                    if (charFound)
                    {
                        break;
                    }
                }
            }

            if (!charFound)
            {
                Console.WriteLine($"{elementToFind} does not occur in the matrix");
            }
        }
    }
}