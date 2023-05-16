using System;

namespace _01.Excursion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int nights = int.Parse(Console.ReadLine());
            int transportCards = int.Parse(Console.ReadLine());
            int museumTickets = int.Parse(Console.ReadLine());

            double costNights = (people * nights) * 20;
            double costTransport = (people * transportCards) * 1.60;
            double costMuseum = (people * museumTickets) * 6;

            double finalPrice = costNights + costTransport + costMuseum;
            double final = finalPrice * 1.25;

            Console.WriteLine($"{final:f2}");
        }
    }
}
    