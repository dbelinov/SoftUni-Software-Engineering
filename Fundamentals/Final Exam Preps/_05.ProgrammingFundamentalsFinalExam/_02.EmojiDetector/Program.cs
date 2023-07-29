using System;
using System.Text.RegularExpressions;

namespace _02.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"([:]{2}|[*]{2})(?<Emoji>[A-Z][a-z]{2,})\1";
            var emojis = Regex.Matches(input, pattern);
            uint threshold = CalculateThreshold(input);
            Console.WriteLine($"Cool threshold: {threshold}");

            Console.WriteLine($"{emojis.Count} emojis found in the text. The cool ones are:");
            
            foreach (Match emoji in emojis)
            {
                string onlyEmoji = emoji.Groups["Emoji"].Value;
                uint emojiScore = 0;
                
                for (int i = 0; i < onlyEmoji.Length; i++)
                {
                    emojiScore += onlyEmoji[i];
                }

                if (emojiScore > threshold)
                {
                    Console.WriteLine(emoji.Value);
                }
            }
        }

        private static uint CalculateThreshold(string input)
        {
            uint threshold = 1;
            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (Char.IsDigit(currentChar))
                {
                    uint digit = (uint)char.GetNumericValue(currentChar);
                    threshold *= digit;
                }
            }
            
            return threshold;
        }
    }
}