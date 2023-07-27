using System;
using System.Collections.Generic;

namespace _03.HeroesofCodeandLogicVII
{
    class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            Name = name;
            HP = hp;
            MP = mp;
        }

        public string Name { get; set; }
        public int HP { get; set; }
        public int MP { get; set; }

        public override string ToString()
        {
            string output = string.Empty;
            output += $"{Name}\n";
            output += $"  HP: {HP}\n";
            output += $"  MP: {MP}";
            return output;
        }
    }
    class Program
    {
        static void Main()
        {
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            int numberOfHeroes = int.Parse(Console.ReadLine());
            for (int i = 0; i < numberOfHeroes; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                string name = tokens[0];
                int hp = int.Parse(tokens[1]);
                int mp = int.Parse(tokens[2]);
                Hero hero = new Hero(name, hp, mp);
                heroes.Add(name, hero);
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split(" - ");
                string heroName = arguments[1];
                switch (arguments[0])
                {
                    case "CastSpell":
                        int mpNeeded = int.Parse(arguments[2]);
                        string spellName = arguments[3];
                        if (heroes[heroName].MP >= mpNeeded)
                        {
                            heroes[heroName].MP -= mpNeeded;
                            Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {heroes[heroName].MP} MP!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
                        }
                        break;
                    case "TakeDamage":
                        int damage = int.Parse(arguments[2]);
                        string attacker = arguments[3];
                        heroes[heroName].HP -= damage;
                        if (heroes[heroName].HP > 0)
                        {
                            Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {heroes[heroName].HP} HP left!");
                        }
                        else
                        {
                            Console.WriteLine($"{heroName} has been killed by {attacker}!");
                            heroes.Remove(heroName);
                        }
                        break;
                    case "Recharge":
                        int amountToRecharge = int.Parse(arguments[2]);
                        int oldMP = heroes[heroName].MP;
                        heroes[heroName].MP += amountToRecharge;
                        if (heroes[heroName].MP > 200)
                        {
                            heroes[heroName].MP = 200;
                        }
                        
                        int amountRecharged = heroes[heroName].MP - oldMP;
                        Console.WriteLine($"{heroName} recharged for {amountRecharged} MP!");
                        break;
                    case "Heal":
                        int amountToHeal = int.Parse(arguments[2]);
                        int oldHP = heroes[heroName].HP;
                        heroes[heroName].HP += amountToHeal;
                        if (heroes[heroName].HP > 100)
                        {
                            heroes[heroName].HP = 100;
                        }

                        int amountHealed = heroes[heroName].HP - oldHP;
                        Console.WriteLine($"{heroName} healed for {amountHealed} HP!");
                        break;
                }
            }

            foreach (Hero hero in heroes.Values)
            {
                Console.WriteLine(hero);
            }
        }
    }
}