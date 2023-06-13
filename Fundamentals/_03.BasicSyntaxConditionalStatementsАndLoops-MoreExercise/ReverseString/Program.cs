using System;

namespace ReverseString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] backwardsInput = input.ToCharArray();
            Array.Reverse(backwardsInput);
            string backwards = new string(backwardsInput);

            Console.WriteLine(backwards);
        }
    }
}