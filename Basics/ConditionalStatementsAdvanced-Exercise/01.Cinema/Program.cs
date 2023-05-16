using System;

namespace _01.Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double ticketPrice = 0;

            switch (projectionType)
            {
                case "Premiere":
                    ticketPrice = 12;
                    break;
                case "Normal":
                    ticketPrice = 7.50;
                    break;
                case "Discount":
                    ticketPrice = 5;
                    break;
            }
                    
                    double totalIncome = rows * columns * ticketPrice;
                    Console.WriteLine($"{totalIncome:F2} leva");
            
        }
    }
}
