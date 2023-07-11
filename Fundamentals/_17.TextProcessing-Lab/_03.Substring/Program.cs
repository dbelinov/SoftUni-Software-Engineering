using System;

namespace _03.Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string match = Console.ReadLine();
            string combination = Console.ReadLine();

            while (true)
            {
                int indexOfMatch = combination.IndexOf(match);
                if (indexOfMatch != -1)
                {
                    combination = combination.Remove(indexOfMatch, match.Length);
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(combination);

        }
    }
}