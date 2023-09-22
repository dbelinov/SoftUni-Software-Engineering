using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ProductShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> stores =
                new Dictionary<string, Dictionary<string, double>>();

            string input;
            while ((input = Console.ReadLine()) != "Revision")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                
                string store = tokens[0];
                string item = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!stores.ContainsKey(store))
                {
                    stores.Add(store, new Dictionary<string, double>());
                }
                stores[store].Add(item, price);
            }

            foreach (var store in stores.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{store.Key}->");
                foreach (var item in store.Value)
                {
                    Console.WriteLine($"Product: {item.Key}, Price: {item.Value}");
                }
            }
        }
    }
}