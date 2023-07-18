using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _02.Race
{
    class Participant
    { 
        public string Name { get; set; }
        public int Distance { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Participant> participants = new List<Participant>();
            string[] names = Console.ReadLine().Split(", ");

            for (int i = 0; i < names.Length; i++)
            {
                Participant participant = new Participant();
                participant.Name = names[i];
                participant.Distance = 0;
                participants.Add(participant);
            }
            
            string letterPattern = @"[A-Za-z]";
            string digitPattern = @"\d";

            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                string info = input;
                StringBuilder name = new StringBuilder();

                foreach (Match match in Regex.Matches(info, letterPattern))
                {
                    name.Append(match.Value);
                }

                int distance = 0;

                foreach (Match match in Regex.Matches(info, digitPattern))
                {
                    distance += int.Parse(match.Value);
                }

                Participant foundParticipant = participants.FirstOrDefault(x => x.Name == name.ToString());
                if (foundParticipant != null)
                {
                    foundParticipant.Distance += distance;
                }
            }

            List<Participant> orderedParticipants = participants
                .OrderByDescending(x => x.Distance)
                .Take(3)
                .ToList();

            if (participants.Count >= 3)
            {
                Console.WriteLine($"1st place: {orderedParticipants[0].Name}");
                Console.WriteLine($"2nd place: {orderedParticipants[1].Name}");
                Console.WriteLine($"3rd place: {orderedParticipants[2].Name}");
            }
        }
    }
}