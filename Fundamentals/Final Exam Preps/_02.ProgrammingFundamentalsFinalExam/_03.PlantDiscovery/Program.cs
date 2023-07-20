using System;
using System.Collections.Generic;
using System.Linq;

/*
3
Arnoldii<->4
Woodii<->7
Welwitschia<->2
Rate: Woodii - 10
Rate: Welwitschia - 7
Rate: Arnoldii - 3
Rate: Woodii - 5
Update: Woodii - 5
Reset: Arnoldii
Exhibition
*/

namespace _03.PlantDiscovery
{
    class Plant
    {
        public Plant(string name, int rarity)
        {
            Name = name;
            Rarity = rarity;
            Ratings = new List<double>();
        }

        public string Name { get; set; }
        public int Rarity { get; set; }
        public List<double> Ratings { get; set; }

        public override string ToString()
        {
            return $"- {Name}; Rarity: {Rarity}; Rating: {CalculateAverageRating(Ratings):f2}";
        }

        public double CalculateAverageRating(List<double> ratings)
        {
            if (ratings.Count == 0)
            {
                return 0.00;
            }

            return ratings.Average();
        }
    }
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            List<Plant> plants = new List<Plant>();
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                string[] tokens = input.Split("<->");
                string name = tokens[0];
                int rarity = int.Parse(tokens[1]);
                Plant foundPlant = plants.FirstOrDefault(x => x.Name == name);
                if (foundPlant == null)
                {
                    Plant plant = new Plant(name, rarity);
                    plants.Add(plant);
                }
                else
                {
                    foundPlant.Rarity = rarity;
                }
            }

            string command;
            while ((command = Console.ReadLine()) != "Exhibition")
            {
                string[] arguments = command.Split(": ");
                switch (arguments[0])
                {
                    case "Rate":
                        string[] tokens = arguments[1].Split(" - ");
                        string plant = tokens[0];
                        double rating = double.Parse(tokens[1]);
                        Plant plantInCollection = plants.FirstOrDefault(x => x.Name == plant);
                        if (plantInCollection != null)
                        {
                            plantInCollection.Ratings.Add(rating);
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Update":
                        string[] updateTokens = arguments[1].Split(" - ");
                        string plantName = updateTokens[0];
                        int newRarity = int.Parse(updateTokens[1]);
                        Plant plantExists = plants.FirstOrDefault(x => x.Name == plantName);
                        if (plantExists != null)
                        {
                            plantExists.Rarity = newRarity;
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                    case "Reset":
                        string plantToReset = arguments[1];
                        Plant plantIsContained = plants.FirstOrDefault(x => x.Name == plantToReset);
                        if (plantIsContained != null)
                        {
                            plantIsContained.Ratings.Clear();
                        }
                        else
                        {
                            Console.WriteLine("error");
                        }
                        break;
                }
            }

            Console.WriteLine("Plants for the exhibition:");
            foreach (Plant plant in plants)
            {
                Console.WriteLine(plant);
            }
        }
    }
}