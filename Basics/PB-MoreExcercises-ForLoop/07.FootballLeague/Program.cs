using System;

namespace _07.FootballLeague
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double staduimCapacity = double.Parse(Console.ReadLine());
            double fans = double.Parse(Console.ReadLine());

            double sectorA = 0;
            double sectorB = 0;
            double sectorV = 0;
            double sectorG = 0;

            for (int i = 0; i < fans; i++)
            {
                string sector = Console.ReadLine();

                if (sector == "A")
                {
                    sectorA++;
                }
                else if (sector == "B")
                {
                    sectorB++;
                }
                else if (sector == "V")
                {
                    sectorV++;
                }
                else
                {
                    sectorG++;
                }
            }

            double percentSectorA = sectorA / fans * 100;
            double percentSectorB = sectorB / fans * 100;
            double percentSectorV = sectorV / fans * 100;
            double percentSectorG = sectorG / fans * 100;
            double percentAllFans = fans / staduimCapacity * 100;

            Console.WriteLine($"{percentSectorA:f2}%");
            Console.WriteLine($"{percentSectorB:f2}%");
            Console.WriteLine($"{percentSectorV:f2}%");
            Console.WriteLine($"{percentSectorG:f2}%");
            Console.WriteLine($"{percentAllFans:f2}%");
        }
    }
}
