using System;
using System.Collections.Generic;

/*
Beer 2.20 100
IceTea 1.50 50
NukaCola 3.30 80
Water 1.00 500
buy
*/

namespace _03.Orders
{
    class Product
    {
        public Product(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public void Update(double price, int quantity)
        {
            Quantity += quantity;
            Price = price;
        }

        private double TotalPrice => Quantity * Price; 

        public override string ToString()
        {
            return $"{Name} -> {TotalPrice:f2}";
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Product> products = new Dictionary<string, Product>();
            string input;
            while ((input = Console.ReadLine()) != "buy")
            {
                string[] tokens = input.Split();
                string name = tokens[0];
                double price = double.Parse(tokens[1]);
                int quantity = int.Parse(tokens[2]);
                Product product = new Product(name, price, quantity);
                if (!products.ContainsKey(name))
                {
                    products.Add(name, product);
                }
                else
                {
                    products[name].Update(price, quantity);
                }
            }

            foreach (var product in products.Values)
            {
                Console.WriteLine(product);
            }
        }
    }
}