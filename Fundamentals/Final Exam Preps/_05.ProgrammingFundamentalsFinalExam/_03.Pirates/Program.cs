using System;
using System.Collections.Generic;

namespace _03.Pirates
{
    class City
    {
        public City(string name, int population, int gold)
        {
            Name = name;
            Population = population;
            Gold = gold;
        }

        public string Name { get; set; }
        public int Population { get; set; }
        public int Gold { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Population: {Population} citizens, Gold: {Gold} kg";
        }
    }
    
    class Program
    {
        static void Main()
        {
            Dictionary<string, City> cities = new Dictionary<string, City>();
            string input;
            while ((input = Console.ReadLine()) != "Sail")
            {
                string[] tokens = input.Split("||");
                string name = tokens[0];
                int population = int.Parse(tokens[1]);
                int gold = int.Parse(tokens[2]);
                if (cities.ContainsKey(name))
                {
                    cities[name].Population += population;
                    cities[name].Gold += gold;
                }
                else
                {
                    City city = new City(name, population, gold);
                    cities.Add(name, city);
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split("=>");
                switch (arguments[0])
                {
                    case "Plunder":
                        string plunderTown = arguments[1];
                        int deadPeople = int.Parse(arguments[2]);
                        int deadGold = int.Parse(arguments[3]);
                        cities[plunderTown].Population -= deadPeople;
                        cities[plunderTown].Gold -= deadGold;
                        Console.WriteLine($"{plunderTown} plundered! {deadGold} gold stolen, {deadPeople} citizens killed.");
                        if (cities[plunderTown].Gold <= 0 || cities[plunderTown].Population <= 0)
                        {
                            cities.Remove(plunderTown);
                            Console.WriteLine($"{plunderTown} has been wiped off the map!");
                        }
                        break;
                    case "Prosper":
                        string prosperTown = arguments[1];
                        int newGold = int.Parse(arguments[2]);
                        if (newGold < 0)
                        {
                            Console.WriteLine("Gold added cannot be a negative number!");
                        }
                        else
                        {
                            cities[prosperTown].Gold += newGold;
                            Console.WriteLine($"{newGold} gold added to the city treasury. {prosperTown} now has {cities[prosperTown].Gold} gold.");
                        }
                        break;
                }
            }

            if (cities.Count > 0)
            {
                Console.WriteLine($"Ahoy, Captain! There are {cities.Count} wealthy settlements to go to:");
                foreach (City city in cities.Values)
                {
                    Console.WriteLine(city);
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
        }
    }
}