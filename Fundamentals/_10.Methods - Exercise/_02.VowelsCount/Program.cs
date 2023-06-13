using System;

namespace _02.VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            char[] inputInLetters = input.ToCharArray();

            Console.WriteLine(CheckForVowel(inputInLetters));
        }

        private static int CheckForVowel(char[] inputInLetters)
        {
            int counter = 0;

            for (int i = 0; i < inputInLetters.Length; i++)
            {
                if (inputInLetters[i] == 97 || inputInLetters[i] == 101 || inputInLetters[i] == 105 ||
                    inputInLetters[i] == 111 || inputInLetters[i] == 117 || inputInLetters[i] == 65 ||
                    inputInLetters[i] == 69 || inputInLetters[i] == 73 || inputInLetters[i] == 79 ||
                    inputInLetters[i] == 85)
                    counter++;
            }
            
            return counter;
        }
    }
}