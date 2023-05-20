using System;

namespace LowerOrUpper
{
    class Program
    {
        static void Main(string[] args)
        {
            char character = char.Parse(Console.ReadLine());

            if (character >= 97 && character <= 122)
            {
                Console.WriteLine("lower-case");
            }
            else if (character >= 65 && character <= 90)
            {
                Console.WriteLine("upper-case");
            }
        }
    }
}