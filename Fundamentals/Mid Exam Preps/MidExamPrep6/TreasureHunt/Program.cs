using System;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunt
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> loot = Console.ReadLine()
                .Split('|')
                .ToList();

            string input = "";
            while ((input = Console.ReadLine()) != "Yohoho!")
            {
                List<string> arguments = input.Split().ToList();

                switch (arguments[0])
                {
                    case "Loot":
                        for (int i = 1; i < arguments.Count; i++)
                        {
                            if (!loot.Contains(arguments[i]))
                            {
                                loot.Insert(0, arguments[i]);
                            }
                        }
                        break;
                    case "Drop":
                        int index = int.Parse(arguments[1]);
                        if (index < loot.Count && index >= 0)
                        {
                            string removedString = loot[index];
                            loot.RemoveAt(index);
                            loot.Add(removedString);
                        }
                        break;
                    case "Steal":
                        int amountStolen = int.Parse(arguments[1]);
                        if (amountStolen >= loot.Count)
                        {
                            Console.WriteLine(String.Join(", ", loot));
                            loot.Clear();
                            continue;
                        }
                        List<string> removedItems = new List<string>();
                        for (int i = 0; i < amountStolen; i++)
                        {
                            string removedItem = loot[loot.Count - 1];
                            loot.RemoveAt(loot.Count - 1);
                            removedItems.Add(removedItem);
                        }

                        removedItems.Reverse();
                        Console.WriteLine(String.Join(", ", removedItems));
                        break;
                }
            }

            double credits = 0;
            foreach (string item in loot)
            {
                credits += item.Length;
            }

            credits /= loot.Count;

            if (loot.Count == 0)
            {
                Console.WriteLine("Failed treasure hunt.");
            }
            else
            {
                Console.WriteLine($"Average treasure gain: {credits:f2} pirate credits.");
            }
        }
    }
}