using System;

namespace BlackFlag
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int dailyPlunder = int.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double plunder = 0;
            for (int day = 1; day <= days; day++)
            {
                plunder += dailyPlunder;
                if (day % 3 == 0)
                {
                    plunder += 0.5 * dailyPlunder;
                }

                if (day % 5 == 0)
                {
                    plunder -= 0.3 * plunder;
                }
            }

            if (plunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {plunder:f2} plunder gained.");
            }
            else
            {
                double percentage = plunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percentage:f2}% of the plunder.");
            }
        }
    }
}