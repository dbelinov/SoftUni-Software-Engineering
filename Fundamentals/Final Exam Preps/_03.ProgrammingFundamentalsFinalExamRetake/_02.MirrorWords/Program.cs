using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _02.MirrorWords
{
    class Pair
    {
        public Pair(string firstWord, string secondWord)
        {
            FirstWord = firstWord;
            SecondWord = secondWord;
        }

        public string FirstWord { get; set; }
        public string SecondWord { get; set; }

        public override string ToString()
        {
            return $"{FirstWord} <=> {SecondWord}";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([@#])(?<wordOne>[A-Za-z]{3,})\1\1(?<wordTwo>[A-Za-z]{3,})\1";
            var matches = Regex.Matches(input, pattern);

            if (matches.Count == 0)
            {
                Console.WriteLine("No word pairs found!");
            }
            else
            {
                Console.WriteLine($"{matches.Count} word pairs found!");
            }

            List<Pair> pairs = new List<Pair>();
            foreach (Match match in matches)
            {
                string firstWord = match.Groups["wordOne"].Value;
                string secondWord = match.Groups["wordTwo"].Value;
                string reversedFirstWord = ReverseString(firstWord);
                if (secondWord == reversedFirstWord)
                {
                    Pair pair = new Pair(firstWord, secondWord);
                    pairs.Add(pair);
                }
            }

            if (pairs.Count > 0)
            {
                Console.WriteLine($"The mirror words are:");
                Console.WriteLine(string.Join(", ", pairs));
            }
            else
            {
                Console.WriteLine("No mirror words!");
            }
            
            
        }
        
        public static string ReverseString(string substring)
        {
            char[] stringAsArr = substring.ToCharArray();
            stringAsArr = stringAsArr.Reverse().ToArray();
            string newString = new string(stringAsArr);
            return newString;
        }
    }
}