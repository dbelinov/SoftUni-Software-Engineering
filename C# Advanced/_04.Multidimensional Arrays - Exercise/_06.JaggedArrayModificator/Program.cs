using System;
using System.Linq;
using System.Threading;
/*
5
10 20 30
1 2 3
2
2
10 10 
End
*/

namespace _06.JaggedArrayModificator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] matrix = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                matrix[row] = values;

                if (row > 0)
                {
                    if (matrix[row].Length == matrix[row - 1].Length)
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            matrix[row][col] *= 2;
                        }
                    
                        for (int col = 0; col < matrix[row - 1].Length; col++)
                        {
                            matrix[row - 1][col] *= 2;
                        }
                    }
                    else
                    {
                        for (int col = 0; col < matrix[row].Length; col++)
                        {
                            matrix[row][col] /= 2;
                        }
                    
                        for (int col = 0; col < matrix[row - 1].Length; col++)
                        {
                            matrix[row - 1][col] /= 2;
                        } 
                    }
                }
            }

            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (row >= 0 && col >= 0 && row < rows && col < matrix[row].Length)
                {
                    switch (tokens[0])
                    {
                        case "Add":
                            matrix[row][col] += value;
                            break;
                        case "Subtract":
                            matrix[row][col] -= value;
                            break;
                    }
                }
            }
            
            foreach (int[] ints in matrix)
            {
                Console.WriteLine(string.Join(" ", ints));
            }
        }
    }
}