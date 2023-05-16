using System;
using System.IO;

namespace _04.TransportPrice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int km = int.Parse(Console.ReadLine());
            string time = Console.ReadLine();

            string typeOfTransport = "";
            double taxiPrice = 0;
            double busPrice = 0;
            double trainPrice = 0;
            double cost = 0;

            if (km < 20)
            {
                typeOfTransport = "taxi";
            }
            else if (km >= 20 && km < 100)
            {
                typeOfTransport = "bus";
            }
            else if (km >= 100)
            {
                typeOfTransport = "train";
            }

            if(typeOfTransport == "taxi")
            {
                if (time == "day")
                {
                    cost = 0.7 + 0.79 * km;
                }
                else if (time == "night")
                {
                    cost = 0.7 + 0.9 * km;
                }
            }
            else if (typeOfTransport == "bus")
            {
                cost = 0.09 * km;
            }
            else if (typeOfTransport == "train")
            {
                cost = 0.06 * km;
            }
            Console.WriteLine($"{cost:F2}");
        }
    }
}
