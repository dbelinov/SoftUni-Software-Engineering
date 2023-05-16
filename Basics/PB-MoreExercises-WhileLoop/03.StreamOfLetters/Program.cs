using System;
using System.Linq;

namespace _03.StreamOfLetters
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            string word = "";
            bool cMet = false;
            bool oMet = false;
            bool nMet = false;
            bool secretUsed = false;
            string currentWord = "";
            

            while (true)
            {
                string input = Console.ReadLine();

                //Stopper
                if (input == "End") break;

                secretUsed = false;

                //Проверка дали е от азбуката
                bool isLetter = input == "a" || input == "b" || input == "c" || input == "d" || input == "e" || input == "f" || input == "g" || input == "h" || input == "i" || input == "j" || input == "k" || input == "l" || input == "m" || input == "n" || input == "o" || input == "p" || input == "q" || input == "r" || input == "s" || input == "t" || input == "u" || input == "v" || input == "w" || input == "x" || input == "y" || input == "z"
                || input == "A" || input == "B" || input == "C" || input == "D" || input == "E" || input == "F" || input == "G" || input == "H" || input == "I" || input == "J" || input == "K" || input == "L" || input == "M" || input == "N" || input == "O" || input == "P" || input == "Q" || input == "R" || input == "S" || input == "T" || input == "U" || input == "V" || input == "W" || input == "X" || input == "Y" || input == "Z";

                if (!isLetter)
                    continue;

                if (input != "c" && input != "o" && input != "n")
                {
                    currentWord += input;
                }

                if (cMet && input == "c") currentWord += input;
                if (oMet && input == "o") currentWord += input;
                if (nMet && input == "n") currentWord += input;

                if (input == "c") cMet = true;
                if (input == "o") oMet = true;
                if (input == "n") nMet = true;

                if (cMet && oMet && nMet)
                {
                    currentWord += " ";
                    cMet = false;
                    oMet = false;
                    nMet = false;
                    secretUsed = true;
                }

                if(secretUsed)
                {
                    word += currentWord;
                    currentWord = "";
                }
               
            }

            Console.WriteLine(word);

        }
    }
}
