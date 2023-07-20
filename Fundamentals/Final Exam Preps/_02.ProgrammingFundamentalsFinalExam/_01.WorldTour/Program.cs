using System;

/*
Hawai::Cyprys-Greece
Add Stop:7:Rome
Remove Stop:11:16
Switch:Hawai:Bulgaria
Travel
*/

namespace _01.WorldTour
{
    class Program
    {
        static void Main(string[] args)
        {
            string stops = Console.ReadLine();

            string command;
            while ((command = Console.ReadLine()) != "Travel")
            {
                string[] tokens = command.Split(':');

                switch (tokens[0])
                {
                    case "Add Stop":
                        int index = int.Parse(tokens[1]);
                        string newStop = tokens[2];
                        if (index >= 0 && index <= stops.Length)
                        {
                            stops = stops.Insert(index, newStop);
                        }
                        break;
                    case "Remove Stop":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        if (startIndex >= 0 && endIndex >= 0 && startIndex < stops.Length && endIndex < stops.Length)
                        {
                            int amountToRemove = endIndex - startIndex + 1;
                            stops = stops.Remove(startIndex, amountToRemove);
                        }
                        break;
                    case "Switch":
                        string oldString = tokens[1];
                        string newString = tokens[2];
                        stops = stops.Replace(oldString, newString);
                        break;
                }

                Console.WriteLine(stops);
            }

            Console.WriteLine($"Ready for world tour! Planned stops: {stops}");
        }
    }
}