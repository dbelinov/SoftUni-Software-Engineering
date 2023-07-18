using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _01.Furniture
{
    class Furniture
    {
        public Furniture(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public double Cost()
        {
            return Price * Quantity;
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @">>(?<Item>[A-Za-z]+)<<(?<Price>\d{1,}.\d{1,}|\d{1,})!(?<Quantity>\d+)";

            List<Furniture> boughtFurniture = new List<Furniture>();
            string input;
            while ((input = Console.ReadLine()) != "Purchase")
            {
                Regex regex = new Regex(pattern);
                MatchCollection collection = regex.Matches(input);

                foreach (Match match in collection)
                {
                    string name = match.Groups["Item"].Value;
                    double price = double.Parse(match.Groups["Price"].Value);
                    int quantity = int.Parse(match.Groups["Quantity"].Value);
                    
                    Furniture furniture = new Furniture(name, price, quantity);
                    boughtFurniture.Add(furniture);
                }
            }

            double totalCost = 0;
            Console.WriteLine("Bought furniture:");
            foreach (var furniture in boughtFurniture)
            {
                Console.WriteLine(furniture.Name);
                totalCost += furniture.Cost();
            }

            Console.WriteLine($"Total money spend: {totalCost:f2}");
        }
    }
}