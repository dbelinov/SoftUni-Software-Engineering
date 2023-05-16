using System;

namespace Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string movie = Console.ReadLine();
            string type = Console.ReadLine();
            int tickets = int.Parse(Console.ReadLine());

            double price = 0;
            
            if (movie == "A Star Is Born")
            {
                if (type == "normal")
                {
                    price = 7.5 * tickets;
                }
                else if (type == "luxury")
                {
                    price = 10.5 * tickets;
                }
                else if (type == "ultra luxury")
                {
                    price = 13.5 * tickets;
                }
            }
            else if (movie == "Bohemian Rhapsody")
            {
                if (type == "normal")
                {
                    price = 7.35 * tickets;
                }
                else if (type == "luxury")
                {
                    price = 9.45 * tickets;
                }
                else if (type == "ultra luxury")
                {
                    price = 12.75 * tickets;
                }
            }else if (movie == "Green Book")
            {
                if (type == "normal")
                {
                    price = 8.15 * tickets;
                }
                else if (type == "luxury")
                {
                    price = 10.25 * tickets;
                }
                else if (type == "ultra luxury")
                {
                    price = 13.25 * tickets;
                }
            }else if (movie == "The Favourite")
            {
                if (type == "normal")
                {
                    price = 8.75 * tickets;
                }
                else if (type == "luxury")
                {
                    price = 11.55 * tickets;
                }
                else if (type == "ultra luxury")
                {
                    price = 13.95 * tickets;
                }
            }

            Console.WriteLine($"{movie} -> {price:f2} lv.");
        }
    }
}