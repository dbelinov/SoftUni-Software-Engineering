using System;
using System.Collections.Generic;

namespace _06.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());

            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();
            for (int i = 0; i < count; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);
                string color = tokens[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int j = 1; j < tokens.Length; j++)
                {
                    string currentClothing = tokens[j];

                    if (!wardrobe[color].ContainsKey(currentClothing))
                    {
                        wardrobe[color].Add(currentClothing, 0);
                    }

                    wardrobe[color][currentClothing]++;
                }
            }

            string[] parameters = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var clothing in color.Value)
                {
                    string printing = $"* {clothing.Key} - {clothing.Value}";

                    if (color.Key == parameters[0] && clothing.Key == parameters[1])
                    {
                        printing += " (found!)";
                    }

                    Console.WriteLine(printing);
                }
            }
        }
    }
}