using System;

namespace _07.HotelRoom
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            double nights = int.Parse(Console.ReadLine());

            double studioPricePerNight = 0;
            double apartmentPricePerNight = 0;

            if (month == "May" || month == "October")
            {
                studioPricePerNight = 50;
                apartmentPricePerNight = 65;
            }
            else if (month == "June" || month == "September")
            {
                studioPricePerNight = 75.20;
                apartmentPricePerNight = 68.70;
            }
            else if (month == "July" || month == "August")
            {
                studioPricePerNight = 76;
                apartmentPricePerNight = 77;
            }

            double finalPriceStudio = nights * studioPricePerNight;
            double finalPriceApartment = nights * apartmentPricePerNight;

            if ((nights > 7 && nights <= 14) && (month == "May" || month == "October"))
            {
                finalPriceStudio = 0.95 * finalPriceStudio;
            }
            else if (nights > 14 && (month == "May" || month == "October"))
            {
                finalPriceStudio = 0.7 * finalPriceStudio;
            }
            else if (nights > 14 && (month == "June" || month == "September"))
            {
                finalPriceStudio = 0.8 * finalPriceStudio;
            }
            
            if (nights > 14)
            {
                finalPriceApartment = 0.9 * finalPriceApartment;
            }

            Console.WriteLine($"Apartment: {finalPriceApartment:F2} lv.");
            Console.WriteLine($"Studio: {finalPriceStudio:F2} lv.");
        }
    }
}
