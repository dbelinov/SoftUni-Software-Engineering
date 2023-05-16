using System;

namespace SchoolSupplies
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amountPens = int.Parse(Console.ReadLine());
            int amountMarkers = int.Parse(Console.ReadLine());
            int Litres = int.Parse(Console.ReadLine()); 
            int percentDiscount = int.Parse(Console.ReadLine());

            double price = (amountPens * 5.80 + amountMarkers * 7.20 + Litres * 1.20);
            double finalPrice = price - price * percentDiscount * 0.01;

            Console.WriteLine(finalPrice);
        }
    }
}
