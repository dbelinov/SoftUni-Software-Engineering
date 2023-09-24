using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.TheV_Logger
{
    class Program
    {
        static void Main()
        {
            //          name       followers/followed    followers
            Dictionary<string, Dictionary<string, HashSet<string>>> vloggers =
                new Dictionary<string, Dictionary<string, HashSet<string>>>();
            
            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string name = tokens[0];
                string command = tokens[1];

                if (command == "joined")
                {
                    if (!vloggers.ContainsKey(name))
                    {
                        vloggers.Add(name, new Dictionary<string, HashSet<string>>());
                        vloggers[name].Add("followers", new HashSet<string>());
                        vloggers[name].Add("following", new HashSet<string>());
                    }
                }
                else if (command == "followed")
                {
                    string followedVlogger = tokens[2];
                    if (vloggers.ContainsKey(name) && 
                        vloggers.ContainsKey(followedVlogger) && 
                        followedVlogger != name)
                    {
                        vloggers[name]["following"].Add(followedVlogger);
                        vloggers[followedVlogger]["followers"].Add(name);
                    }
                }
            }

            int count = 1;
            
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count} vloggers in its logs.");

            var orderedVloggers = vloggers
                .OrderByDescending(x => x.Value["followers"].Count)
                .ThenBy(x => x.Value["following"].Count)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var vlogger in orderedVloggers)
            {
                Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");

                if (count == 1)
                {
                    foreach (var follower in vlogger.Value["followers"].OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {follower}");
                    }
                }

                count++;
            }
        }
    }
}