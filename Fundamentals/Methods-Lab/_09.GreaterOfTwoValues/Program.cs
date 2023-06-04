using System;
using System.Runtime.InteropServices;

namespace _09.GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string typeOfValues = Console.ReadLine();
            GetMax(typeOfValues);
        }

        private static void GetMax(string typeOfValues)
        {
            
            switch (typeOfValues)
            {
                case "int":
                    int first = int.Parse(Console.ReadLine());
                    int second = int.Parse(Console.ReadLine());
                    if (first > second)
                        Console.WriteLine(first);
                    else
                        Console.WriteLine(second);
                    break;
                case "char":
                    char firstChar = char.Parse(Console.ReadLine());
                    char secondChar = char.Parse(Console.ReadLine());
                    if (firstChar > secondChar)
                        Console.WriteLine(firstChar);
                    else
                        Console.WriteLine(secondChar);
                    break;
                case "string":
                    string input = Console.ReadLine();
                    char biggestChar = 'a';
                    char[] inputAsChar = input.ToCharArray();
                    for (int i = 0; i < inputAsChar.Length; i++)
                    {
                        if (inputAsChar[i] > biggestChar)
                        {
                            biggestChar = inputAsChar[i];
                        }
                    }

                    Console.WriteLine(biggestChar);
                    break;
            }
        }
    }
}