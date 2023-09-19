using System;
using System.Linq;
/*
3
1 2 3
4 5 6
7 8 9
Add 0 0 5
Subtract 1 1 2
END
 
 

4
1 2 3 4
5
8 7 6 5
4 3 2 1
Add 4 4 100
Add 3 3 100
Subtract -1 -1 42
Subtract 0 0 42
END
*/    
namespace _06.JaggedArrayModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                int[] values = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
                matrix[row] = values;
            }

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                
                switch (tokens[0])
                {
                    case "Add":
                        if (row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length)
                        {
                            matrix[row][col] += value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                    case "Subtract":
                        if (row >= 0 && col >= 0 && row < matrix.Length && col < matrix[row].Length)
                        {
                            matrix[row][col] -= value;
                        }
                        else
                        {
                            Console.WriteLine("Invalid coordinates");
                        }
                        break;
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }

                Console.WriteLine();
            }
        }
    }
}