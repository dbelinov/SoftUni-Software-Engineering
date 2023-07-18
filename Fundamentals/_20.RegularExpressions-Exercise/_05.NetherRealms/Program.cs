using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _05.NetherRealms
{
    class Demon
    {
        public Demon(string name, int health, decimal damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public string Name { get; set; }
        public int Health { get; set; }
        public decimal Damage { get; set; }

        public override string ToString()
        {
            return $"{Name} - {Health} health, {Damage:f2} damage";
        }
    }
    class Program
    {
        static void Main()
        {
            
            string[] demons = Console
                .ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            List<Demon> demonsCategorised = new List<Demon>();
            foreach (string demonName in demons)
            {
                int health = CalculateHealth(demonName);
                decimal damage = CalculateDamage(demonName);
                
                Demon demon = new Demon(demonName, health, damage);
                demonsCategorised.Add(demon);
            }

            List<Demon> sortedDemons = demonsCategorised.OrderBy(x => x.Name).ToList();

            foreach (Demon demon in sortedDemons)
            {
                Console.WriteLine(demon);
            }
            
        }

        public static int CalculateHealth(string demonName)
        {
            string healthPattern = @"[^0-9\+\-\*\/\.]";
            int health = 0;
            foreach (Match match in Regex.Matches(demonName, healthPattern))
            {
                char matchAsChar = char.Parse(match.Value);
                health += matchAsChar;
            }

            return health;
        }

        public static decimal CalculateDamage(string demonName)
        {
            string damagePattern = @"(?:(?:[-+]*)(?:\d+\.\d+|\d+))";
            decimal damage = 0;
            foreach (Match match in Regex.Matches(demonName, damagePattern))
            {
                decimal number;
                decimal.TryParse(match.Value, out number);
                damage += number;
            }
            
            string modifyingDamagePattern = @"[\*\/]";
            foreach (Match match in Regex.Matches(demonName, modifyingDamagePattern))
            {
                switch (match.Value)
                {
                    case "*":
                        damage *= 2;
                        break;
                    case "/":
                        damage /= 2;
                        break;
                }
            }
            
            return damage;
        }
    }
}