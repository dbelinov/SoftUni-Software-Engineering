using System;
using System.Linq;
/*
2 3
1 2 3
4 5 6
swap 0 0 1 1
swap 10 9 8 7
swap 0 1 1 0
END

1 2
Hello World
0 0 0 1
swap 0 0 0 1
swap 0 1 0 0
END
      
*/

namespace _04.MatrixShuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int rows = sizes[0];
            int cols = sizes[1];

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] values = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = values[col];
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                // int row1 = int.Parse(tokens[1]);
                // int col1 = int.Parse(tokens[2]);
                // int row2 = int.Parse(tokens[3]);
                // int col2 = int.Parse(tokens[4]);

                if (tokens[0] != "swap" || tokens.Length < 5)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                
                if (int.Parse(tokens[1]) < 0 
                    || int.Parse(tokens[1]) >= rows
                    || int.Parse(tokens[2]) < 0 
                    || int.Parse(tokens[2]) >= cols
                    || int.Parse(tokens[3]) < 0 
                    || int.Parse(tokens[3]) >= rows
                    || int.Parse(tokens[4]) < 0 
                    || int.Parse(tokens[4]) >= cols)
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                
                int row1 = int.Parse(tokens[1]);
                int col1 = int.Parse(tokens[2]);
                int row2 = int.Parse(tokens[3]);
                int col2 = int.Parse(tokens[4]);
                    
                string temp = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = temp;

                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        Console.Write($"{matrix[row, col]} ");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
