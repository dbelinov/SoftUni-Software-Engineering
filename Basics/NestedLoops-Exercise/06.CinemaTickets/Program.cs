using System;

namespace _06.CinemaTickets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int standartTickets = 0;
            int studentTickets = 0;
            int kidTickets = 0;
            int totalTickets = 0;

            while (name != "Finish")
            {
                int freeSeats = int.Parse(Console.ReadLine());

                
                int amountOfSoldTickets = 0;

                while (amountOfSoldTickets < freeSeats)
                {
                    string typeOfSeat = Console.ReadLine();
                    if (typeOfSeat == "End") break;
                    if (typeOfSeat == "standard")
                    {
                        standartTickets++;
                        amountOfSoldTickets++;
                    }
                    else if (typeOfSeat == "student")
                    {
                        studentTickets++;
                        amountOfSoldTickets++;
                    }
                    else
                    {
                        kidTickets++;
                        amountOfSoldTickets++;
                    }
                }
                totalTickets += amountOfSoldTickets;
                double percentageFilled = (double)amountOfSoldTickets / freeSeats * 100;

                Console.WriteLine($"{name} - {percentageFilled:f2}% full.");
                name = Console.ReadLine();
            }
            Console.WriteLine($"Total tickets: {totalTickets}");

            double percentageStudent = (double)studentTickets / totalTickets * 100;
            Console.WriteLine($"{percentageStudent:f2}% student tickets.");

            double percentageStandart = (double)standartTickets / totalTickets * 100;
            Console.WriteLine($"{percentageStandart:f2}% standard tickets.");

            double percentageKid = (double)kidTickets / totalTickets * 100;
            Console.WriteLine($"{percentageKid:f2}% kids tickets.");
        }
    }
}
