using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participants = new Dictionary<string, int>();
            Dictionary<string, int> languages = new Dictionary<string, int>();
            
            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                string username = tokens[0];

                if (tokens[1] == "banned")
                {
                    participants.Remove(username);
                    continue;
                }
                
                string language = tokens[1];
                int points = int.Parse(tokens[2]);

                if (!participants.ContainsKey(username))
                {
                    participants.Add(username, 0);
                }

                if (participants[username] < points)
                {
                    participants[username] = points;
                }

                if (!languages.ContainsKey(language))
                {
                    languages.Add(language, 0);
                }

                languages[language]++;
            }

            Dictionary<string, int> orderedParticipants = participants
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            
            Dictionary<string, int> orderedContests = languages
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);
            
            Console.WriteLine("Results:");
            foreach (var participant in orderedParticipants)
            {
                Console.WriteLine($"{participant.Key} | {participant.Value}");
            }

            Console.WriteLine("Submissions:");

            foreach (var contest in orderedContests)
            {
                Console.WriteLine($"{contest.Key} - {contest.Value}");
            }
        }
    }
}