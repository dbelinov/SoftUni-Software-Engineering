using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> shopping = Console.ReadLine()
                .Split('!')
                .ToList();

            string input = "";

            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                List<string> arguments = input.Split().ToList();

                switch (arguments[0])
                {
                    case "Urgent":
                        if (!shopping.Contains(arguments[1]))
                        {
                            shopping.Insert(0, arguments[1]);
                        }
                        break;
                    case "Unnecessary":
                        if (shopping.Contains(arguments[1]))
                        {
                            shopping.Remove(arguments[1]);
                        }
                        break;
                    case "Correct":
                        if (shopping.Contains(arguments[1]))
                        {
                            int indexOfString = shopping.IndexOf(arguments[1]);
                            shopping[indexOfString] = arguments[2];
                        }
                        break;
                    case "Rearrange":
                        if (shopping.Contains(arguments[1]))
                        {
                            shopping.Remove(arguments[1]);
                            shopping.Add(arguments[1]);
                        }
                        break;
                }
            }

            Console.WriteLine(String.Join(", ", shopping));
        }
    }
}