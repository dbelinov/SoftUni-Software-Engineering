using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VendingSystem
{
    public class VendingMachine
    {
        public int ButtonCapacity { get; set; }
        public List<Drink> Drinks { get; set; }
        public int GetCount { get; private set; }

        public VendingMachine(int buttonCapacity)
        {
            ButtonCapacity = buttonCapacity;
            Drinks = new List<Drink>();
            GetCount = 0;
        }

        public void AddDrink(Drink drink)
        {
            if (Drinks.Count + 1 <= ButtonCapacity)
            {
                Drinks.Add(drink);
                GetCount++;
            }
        }

        public bool RemoveDrink(string name)
        {
            Drink foundDrink = Drinks.FirstOrDefault(d => d.Name == name);
            if (foundDrink != null)
            {
                Drinks.Remove(foundDrink);
                return true;
            }
            return false;
        }

        public Drink GetLongest()
        {
            return Drinks.MaxBy(d => d.Volume);
        }

        public Drink GetCheapest()
        {
            return Drinks.MinBy(d => d.Price);
        }

        public string BuyDrink(string name)
        {
            return Drinks.First(d => d.Name == name).ToString();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Drinks available:");
            foreach (Drink drink in Drinks)
            {
                sb.AppendLine(drink.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
