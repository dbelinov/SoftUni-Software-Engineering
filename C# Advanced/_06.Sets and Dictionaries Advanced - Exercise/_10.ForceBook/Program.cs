using System;
using System.Collections.Generic;
using System.Linq;

/*
e | b
e | a
f | d
f | c
f | e
g | e
*/

namespace _10.ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, HashSet<string>> sides = new Dictionary<string, HashSet<string>>();
            
            string input;
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {
                if (input.Contains("|"))
                {
                    string[] tokens = input.Split(" | ", StringSplitOptions.RemoveEmptyEntries);
                    
                    string side = tokens[0];
                    string name = tokens[1];

                    if (!sides.Values.Any(x => x.Contains(name)))
                    {
                        if (!sides.ContainsKey(side))
                        {
                            sides.Add(side, new HashSet<string>());
                        }
                        
                        sides[side].Add(name);
                    }
                    
                }
                else
                {
                    string[] tokens = input.Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                    
                    string name = tokens[0];
                    string newSide = tokens[1];

                    foreach (var side in sides)
                    {
                        if (side.Value.Contains(name))
                        {
                            side.Value.Remove(name);
                            break;
                        }
                    }

                    if (!sides.ContainsKey(newSide))
                    {
                        sides.Add(newSide, new HashSet<string>());
                    }

                    sides[newSide].Add(name);

                    Console.WriteLine($"{name} joins the {newSide} side!");
                }
            }

            foreach (var side in sides)
            {
                if (side.Value.Count == 0)
                {
                    sides.Remove(side.Key);
                }
            }

            Dictionary<string, HashSet<string>> orderedSides = sides
                .OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            
            foreach (var side in orderedSides)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count}");
                foreach (var user in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }
    }
}