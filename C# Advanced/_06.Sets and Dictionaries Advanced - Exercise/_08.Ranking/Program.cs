using System;
using System.Collections.Generic;
using System.Linq;

/*
Part One Interview:success
Js Fundamentals:JSFundPass
C# Fundamentals:fundPass
Algorithms:fun
end of contests
C# Fundamentals=>fundPass=>Tanya=>350
Algorithms=>fun=>Tanya=>380
Part One Interview=>success=>Nikola=>120
Java Basics Exam=>JSFundPass=>Parker=>400
Part One Interview=>success=>Tanya=>220
OOP Advanced=>password123=>BaiIvan=>231
C# Fundamentals=>fundPass=>Tanya=>250
C# Fundamentals=>fundPass=>Nikola=>200
Js Fundamentals=>JSFundPass=>Tanya=>400
end of submissions
*/

namespace _08.Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsCreds = new Dictionary<string, string>();
            SortedDictionary<string, Dictionary<string, int>> contestParticipants =
                new SortedDictionary<string, Dictionary<string, int>>();
            
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                
                string contestName = tokens[0];
                string password = tokens[1];
                
                contestsCreds.Add(contestName, password);
            }

            string entry;
            while ((entry = Console.ReadLine()) != "end of submissions")
            {
                string[] tokens = entry.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                
                string contest = tokens[0];
                string password = tokens[1];
                string username = tokens[2];
                int points = int.Parse(tokens[3]);

                if (contestsCreds.ContainsKey(contest) && contestsCreds[contest] == password)
                {
                    if (!contestParticipants.ContainsKey(username))
                    {
                        contestParticipants.Add(username, new Dictionary<string, int>());
                    }

                    if (!contestParticipants[username].ContainsKey(contest))
                    {
                        contestParticipants[username].Add(contest, 0);
                    }

                    if (contestParticipants[username][contest] < points)
                    {
                        contestParticipants[username][contest] = points;
                    }
                }
            }

            string bestCandidate = contestParticipants
                .OrderByDescending(x => x.Value.Values.Sum())
                .First().Key;
            int bestCandidatePoints = contestParticipants[bestCandidate].Values.Sum();

            Console.WriteLine($"Best candidate is {bestCandidate} with total {bestCandidatePoints} points.");

            Console.WriteLine("Ranking:");
            foreach (var participant in contestParticipants)
            {
                Console.WriteLine($"{participant.Key}");

                foreach (var contest in participant.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}