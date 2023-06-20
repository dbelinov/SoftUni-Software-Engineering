using System;
using System.Collections.Generic;
using System.Linq;

namespace ManOWar
{
    class Program
    {
        static void Main()
        {
            List<int> PirateShipStatus = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToList();

            List<int> WarShipStatus = Console.ReadLine()
                .Split('>')
                .Select(int.Parse)
                .ToList();

            int maxHealth = int.Parse(Console.ReadLine());

            string input = "";
            
            while ((input = Console.ReadLine()) != "Retire")
            {
                string[] tokens = input.Split().ToArray();

                switch (tokens[0])
                {
                    case "Fire":
                        int index = int.Parse(tokens[1]);
                        int damageFired = int.Parse(tokens[2]);
                        if (index >= 0 && index < WarShipStatus.Count)
                        {
                            WarShipStatus[index] -= damageFired;
                            if (WarShipStatus[index] <= 0)
                            {
                                Console.WriteLine("You won! The enemy ship has sunken.");
                                return;
                            }
                        }
                        break;
                    case "Defend":
                        int startIndex = int.Parse(tokens[1]);
                        int endIndex = int.Parse(tokens[2]);
                        int damageDefended = int.Parse(tokens[3]);

                        if (startIndex >= 0 && startIndex < endIndex && endIndex < PirateShipStatus.Count)
                        {
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                PirateShipStatus[i] -= damageDefended;
                                if (PirateShipStatus[i] <= 0)
                                {
                                    Console.WriteLine("You lost! The pirate ship has sunken.");
                                    return;
                                }
                            }
                        }
                        break;
                    case "Repair":
                        int indexOfRepair = int.Parse(tokens[1]);
                        int healthRepaired = int.Parse(tokens[2]);

                        if (indexOfRepair >= 0 && indexOfRepair < PirateShipStatus.Count)
                        {
                            PirateShipStatus[indexOfRepair] += healthRepaired;

                            if (PirateShipStatus[indexOfRepair] > maxHealth)
                            {
                                PirateShipStatus[indexOfRepair] = maxHealth;
                            }
                        }
                        break;
                    case "Status":
                        int needRepair = 0;
                        double requiredHealth = 0.2 * maxHealth;
                        foreach (int section in PirateShipStatus)
                        {
                            if (section < requiredHealth)
                            {
                                needRepair++;
                            }
                        }

                        Console.WriteLine($"{needRepair} sections need repair.");
                        break;
                }
            }

            int sumOfPirateShip = 0;
            int sumOfWarShip = 0;

            foreach (int section in PirateShipStatus)
            {
                sumOfPirateShip += section;
            }

            foreach (int section in WarShipStatus)
            {
                sumOfWarShip += section;
            }
            
            Console.WriteLine($"Pirate ship status: {sumOfPirateShip}");
            Console.WriteLine($"Warship status: {sumOfWarShip}");
        }
    }
}