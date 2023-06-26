using System;
using System.Collections.Generic;
using System.Linq;

/*
19861519 Dove 15 2.50
86757035 Butter 7 3.20
39393891 Orbit 16 1.60
37741865 Samsung 10 1000
end
*/

namespace _06.StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> boxes = new List<Box>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
                int serialNumber = int.Parse(tokens[0]);
                string itemName = tokens[1];
                int itemQuantity = int.Parse(tokens[2]);
                decimal itemPrice = decimal.Parse(tokens[3]);

                Item item = new Item(itemName, itemPrice);
                Box box = new Box(serialNumber, item, itemQuantity);

                boxes.Add(box);
            }

            List<Box> sortedBoxes = boxes.OrderByDescending(x => x.BoxPrice).ToList();

            foreach (Box box in sortedBoxes)
            {
                Console.WriteLine(box);
            }
        }
    }

    public class Item
    {
        public Item(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    public class Box
    {
        public Box(int serialNumber, Item item, int itemQuantity)
        {
            SerialNumber = serialNumber;
            Item = item;
            ItemQuantity = itemQuantity;
            BoxPrice = CalculateBoxPrice(itemQuantity, item.Price);
        }
        
        public int SerialNumber { get; set; }
        public Item Item { get; set; }
        public int ItemQuantity { get; set; }
        public decimal BoxPrice { get; set; }

        private static decimal CalculateBoxPrice(int itemQuantity, decimal itemPrice)
        {
            decimal boxPrice = itemQuantity * itemPrice;
            return boxPrice;
        }

        public override string ToString()
        {
            string output = "";
            output += $"{SerialNumber}\n";
            output += $"-- {Item.Name} - ${Item.Price:f2}: {ItemQuantity}\n";
            output += $"-- ${BoxPrice:f2}";
            return output;
        }
    }
}