using System;

namespace _07.Moving
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int width = int.Parse(Console.ReadLine());
            int length = int.Parse(Console.ReadLine());
            int heigth = int.Parse(Console.ReadLine());

            int size = width * length * heigth;
            int startingSize = size;
            int boxesSum = 0;

            while (size >= 0)
            {
                string input = Console.ReadLine();

                if (input == "Done") break;

                int boxes = int.Parse(input);
                boxesSum += boxes;
                size -= boxes;
            }

            if (size >= 0)
            {
                Console.WriteLine($"{size} Cubic meters left.");
            }
            else
            {
                Console.WriteLine($"No more free space! You need {boxesSum - startingSize} Cubic meters more.");
            }
        }
    }
}
