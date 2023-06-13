using System;

namespace _03.CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstCharacter = char.Parse(Console.ReadLine());
            char secondCharacter = char.Parse(Console.ReadLine());

            if (firstCharacter > secondCharacter)
            {
                char temp = firstCharacter;
                firstCharacter = secondCharacter;
                secondCharacter = temp;
            }

            PrintCharsInRange(firstCharacter, secondCharacter);
        }

        private static void PrintCharsInRange(char firstCharacter, char secondCharacter)
        {
            for (int i = firstCharacter + 1; i < secondCharacter; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}