using System;
using System.Collections.Generic;

namespace _07.ParkingLot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string licencePlate = tokens[1];

                switch (command)
                {
                    case "IN":
                        parking.Add(licencePlate);
                        break;
                    case "OUT":
                        if (parking.Contains(licencePlate))
                        {
                            parking.Remove(licencePlate);
                        }
                        break;
                }
            }

            if (parking.Count > 0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}