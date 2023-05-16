using System;

namespace _07.MinNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int minNum = int.MaxValue;

            while (input != "Stop")
            {
                int currentNum = int.Parse(input);

                if (currentNum < minNum)
                {
                    minNum = currentNum;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(minNum);
        }
    }
}
