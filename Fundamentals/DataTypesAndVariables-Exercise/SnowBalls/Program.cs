using System;
using System.Numerics;

namespace SnowBalls
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfSnowballs = int.Parse(Console.ReadLine());

            BigInteger biggestValue = 0;
            BigInteger biggestSnow = 0;
            BigInteger biggestTime = 0;
            BigInteger biggestQuality = 0;
            for (int i = 1; i <= numberOfSnowballs; i++)
            {
                BigInteger snow = BigInteger.Parse(Console.ReadLine());
                BigInteger time = BigInteger.Parse(Console.ReadLine());
                int quality = int.Parse(Console.ReadLine());

                BigInteger value = BigInteger.Pow((snow / time), quality);

                if (value > biggestValue)
                {
                    biggestValue = value;
                    biggestSnow = snow;
                    biggestTime = time;
                    biggestQuality = quality;
                }
            }

            Console.WriteLine($"{biggestSnow} : {biggestTime} = {biggestValue} ({biggestQuality})");
        }
    }
}