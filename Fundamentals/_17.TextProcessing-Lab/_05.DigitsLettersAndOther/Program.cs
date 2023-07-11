using System;

namespace _05.DigitsLettersAndOther
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string nums = "";
            string letters = "";
            string symbols = "";
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (char.IsDigit(currentChar))
                {
                    nums += currentChar;
                }
                else if (char.IsLetter(currentChar))
                {
                    letters += currentChar;
                }
                else
                {
                    symbols += currentChar;
                }
            }

            Console.WriteLine(nums);
            Console.WriteLine(letters);
            Console.WriteLine(symbols);
        }
    }
}