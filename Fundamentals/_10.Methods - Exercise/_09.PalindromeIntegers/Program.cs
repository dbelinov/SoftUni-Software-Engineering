using System;
using System.Linq;

namespace _09.PalindromeIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                bool isPalindrome = CheckIfPalindrome(input);
                Console.WriteLine(isPalindrome);
            }
        }

        private static bool CheckIfPalindrome(string input)
        {
            string reversedInput = new string(input.Reverse().ToArray());
            return input == reversedInput;
        }
    }
}