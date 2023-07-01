using System;
using System.Collections.Generic;
using System.Linq;

/*
2
John-PowerPuffsCoders
Tony-Tony is the best
Peter->PowerPuffsCoders
Tony->Tony is the best
end of assignment
*/

namespace _05.TeamworkProjects
{
    class Team
    {
        public Team(string name, string creator)
        {
            Name = name;
            Creator = creator;
            Members = new List<string>();
        }

        public string Name { get; set; }
        public string Creator { get; set; }
        public List<string> Members { get; set; }

        public override string ToString()
        {
            Members.Sort();

            string result = "";
            
            result += Name + "\n";
            result += $"- {Creator} \n";
            foreach (var member in Members)
            {
                result += $"-- {member}\n";
            }

            return result.Trim();
        }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();
            int teamsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < teamsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split('-');
                string creator = tokens[0];
                string teamName = tokens[1];

                Team sameTeamFound = teams.Find(team => team.Name == teamName);
                Team sameCreatorFound = teams.Find(team => team.Creator == creator);
                if (sameTeamFound != null)
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                    continue;
                }

                if (sameCreatorFound != null)
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                    continue;
                }
                
                Team team = new Team(teamName, creator);
                teams.Add(team);
                Console.WriteLine($"Team {teamName} has been created by {creator}!");
            }

            string input;
            while ((input = Console.ReadLine()) != "end of assignment")
            {
                string[] tokens = input.Split("->");
                string user = tokens[0];
                string teamName = tokens[1];

                if (!teams.Any(team => team.Name == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                    continue;
                }

                if (teams.Any(team => team.Creator == user) || 
                    teams.Any(team => team.Members.Contains(user)))
                {
                    Console.WriteLine($"Member {user} cannot join team {teamName}!");
                    continue;
                }
                
                teams.Find(team => team.Name == teamName).Members.Add(user);
            }

            List<Team> leftTeams = teams.Where(team => team.Members.Count > 0).ToList();
            List<Team> disbandTeams = teams.Where(team => team.Members.Count <= 0).ToList();

            List<Team> orderedTeams = leftTeams
                .OrderByDescending(team => team.Members.Count)
                .ThenBy(team => team.Name)
                .ToList();
            
            orderedTeams.ForEach(team => Console.WriteLine(team));

            Console.WriteLine("Teams to disband:");
            orderedTeams = disbandTeams.OrderBy(team => team.Name).ToList();
            foreach (var team in orderedTeams)
            {
                Console.WriteLine(team.Name);
            }
        }
    }
}