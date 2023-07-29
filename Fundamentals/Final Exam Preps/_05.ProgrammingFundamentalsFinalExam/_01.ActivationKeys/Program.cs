using System;
using System.Linq;
using System.Text;

namespace _01.ActivationKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder key = new StringBuilder(Console.ReadLine());
            
            string command;
            while ((command = Console.ReadLine()) != "Generate")
            {
                string[] tokens = command.Split(">>>");
                switch (tokens[0])
                {
                    case "Contains":
                        string substring = tokens[1];
                        if (key.ToString().Contains(substring))
                        {
                            Console.WriteLine($"{key} contains {substring}");
                        }
                        else
                        {
                            Console.WriteLine("Substring not found!");
                        }
                        break;
                    case "Flip":
                        int startIndex = int.Parse(tokens[2]);
                        int endIndex = int.Parse(tokens[3]);
                        if (tokens[1] == "Upper")
                        {
                            for (int i = startIndex; i < endIndex; i++)
                            {
                                key[i] = Char.ToUpper(key[i]);
                            }
                        }
                        else if (tokens[1] == "Lower")
                        {
                            for (int i = startIndex; i < endIndex; i++)
                            {
                                key[i] = Char.ToLower(key[i]);
                            }
                        }

                        Console.WriteLine(key);
                        break;
                    case "Slice":
                        int start = int.Parse(tokens[1]);
                        int end = int.Parse(tokens[2]);
                        int lengthToCut = end - start;
                        key = key.Remove(start, lengthToCut);
                        Console.WriteLine(key);
                        break;
                }
            }

            Console.WriteLine($"Your activation key is: {key}");
        }
    }
}