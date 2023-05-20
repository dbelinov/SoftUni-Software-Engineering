using System;

namespace BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            string biggestKeg = "";
            double biggestKegVolume = 0;
            for (int i = 1; i <= n; i++)
            {
                string name = Console.ReadLine();
                double radiusOfKeg = double.Parse(Console.ReadLine());
                int heightOfKeg = int.Parse(Console.ReadLine());

                double volume = Math.PI * (radiusOfKeg * radiusOfKeg) * heightOfKeg;
                if (volume >= biggestKegVolume)
                {
                    biggestKegVolume = volume;
                    biggestKeg = name;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}