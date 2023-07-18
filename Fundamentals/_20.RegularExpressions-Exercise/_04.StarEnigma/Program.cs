using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/*
3
tt(''DGsvywgerx>6444444444%H% 1B9444
GQhrr|A977777(H(TTTT 
EHfsytsnhf?8555&I&2C9555SR
*/

namespace _04.StarEnigma
{
    class Message
    {
        public Message(string name, int population, string attackType, int soldierCount)
        {
            Name = name;
            Population = population;
            AttackType = attackType;
            SoldierCount = soldierCount;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public string AttackType { get; set; }
        public int SoldierCount { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Message> messages = new List<Message>();
            
            int messageCount = int.Parse(Console.ReadLine());

            string starPattern = @"[SsTtAaRr]";
            string pattern = @"@(?<Name>[A-Za-z]+)[^@\-!:>]*?:(?<Population>\d+)[^@\-!:>]*?\!(?<Attack>[AD])\![^@\-!:>]*?\-\>(?<Soldiers>\d+)";

            for (int i = 0; i < messageCount; i++)
            {
                string messageToEncrypt = Console.ReadLine();

                int decryptionKey = Regex.Matches(messageToEncrypt, starPattern).Count;

                StringBuilder stringBuilder = new StringBuilder();
                for (int j = 0; j < messageToEncrypt.Length; j++)
                {
                    stringBuilder.Append((char)(messageToEncrypt[j] - decryptionKey));
                }

                string encryptedMessage = stringBuilder.ToString();

                if (!Regex.IsMatch(encryptedMessage, pattern))
                {
                    continue;
                }
                var match = Regex.Match(encryptedMessage, pattern);

                string name = match.Groups["Name"].Value;
                int population = int.Parse(match.Groups["Population"].Value);
                string attackType = match.Groups["Attack"].Value;
                int soldierAmount = int.Parse(match.Groups["Soldiers"].Value);

                Message message = new Message(name, population, attackType, soldierAmount);
                messages.Add(message);
            }

            List<Message> attackedPlanets = messages.Where(x => x.AttackType == "A").OrderBy(x => x.Name).ToList();
            List<Message> destroyedPlanets = messages.Where(x => x.AttackType == "D").OrderBy(x => x.Name).ToList();

            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (var attackedPlanet in attackedPlanets)
            {
                Console.WriteLine($"-> {attackedPlanet.Name}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (var destroyedPlanet in destroyedPlanets)
            {
                Console.WriteLine($"-> {destroyedPlanet.Name}");
            }
        }
    }
}