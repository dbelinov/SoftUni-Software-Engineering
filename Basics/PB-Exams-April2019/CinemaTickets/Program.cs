using System;

namespace CinemaTickets
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int totalTickets = 0;
            int ticketsForMovie = 0;
            int studentTickets = 0;
            int standartTickets = 0;
            int kidTickets = 0;
            
            while (input != "Finish")
            {
                string movieName = input;
                int freeSpots = int.Parse(Console.ReadLine());

                for (int i = 1; i <= freeSpots; i++)
                {
                    string type = Console.ReadLine();
                    if (type == "End")
                        break;

                    if (type == "student")
                        studentTickets++;
                    else if (type == "standard")
                        standartTickets++;
                    else if (type == "kid")
                        kidTickets++;

                    totalTickets++;
                    ticketsForMovie++;
                }

                Console.WriteLine($"{movieName} - {(double)ticketsForMovie / freeSpots * 100:f2}% full.");
                ticketsForMovie = 0;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Total tickets: {totalTickets}");
            Console.WriteLine($"{(double)studentTickets / totalTickets * 100:f2}% student tickets.");
            Console.WriteLine($"{(double)standartTickets / totalTickets * 100:f2}% standard tickets.");
            Console.WriteLine($"{(double)kidTickets / totalTickets * 100:f2}% kids tickets.");
        }
    }
}