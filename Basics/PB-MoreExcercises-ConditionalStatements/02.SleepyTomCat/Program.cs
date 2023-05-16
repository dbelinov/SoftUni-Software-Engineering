using System;

namespace _02.SleepyTomCat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int breakDays = int.Parse(Console.ReadLine());

            int workDays = 365 - breakDays;

            int playTimeWork = workDays * 63;
            int playTimeBreak = breakDays * 127;
            int playTime = playTimeWork + playTimeBreak;

            if(playTime < 30000)
            {
                int over = 30000 - playTime;
                int overHours = over / 60;
                int overMinutes = over % 60;
                Console.WriteLine("Tom sleeps well");
                Console.WriteLine($"{overHours} hours and {overMinutes} minutes less for play");
            }
            else
            {
                int under = playTime - 30000;
                int underHours = under / 60;
                int underMinutes = under % 60;
                Console.WriteLine("Tom will run away");
                Console.WriteLine($"{underHours} hours and {underMinutes} minutes more for play");
            }
        }
    }
}
