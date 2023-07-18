using System;
using System.Text.RegularExpressions;

namespace _03.SoftUniBarIncome
{
    class Order
    {
        public string Name { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        public decimal Total()
        {
            return Price * Quantity;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\%(?<Name>[A-Z][a-z]+)\%[^|$%.]*\<(?<Item>\w+)\>[^|$%.]*\|(?<Quantity>\d+)\|[^|$%.]*?(?<Price>\d+|\d+\.\d+)\$";
            string input;
            decimal income = 0;
            while ((input = Console.ReadLine()) != "end of shift")
            {
                foreach (Match match in Regex.Matches(input, pattern))
                {
                    Order order = new Order();
                    order.Name = match.Groups["Name"].Value;
                    order.Item = match.Groups["Item"].Value;
                    order.Quantity = int.Parse(match.Groups["Quantity"].Value);
                    order.Price = decimal.Parse(match.Groups["Price"].Value);

                    Console.WriteLine($"{order.Name}: {order.Item} - {order.Total():f2}");

                    income += order.Total();
                }
            }

            Console.WriteLine($"Total income: {income:f2}");
        }
    }
}