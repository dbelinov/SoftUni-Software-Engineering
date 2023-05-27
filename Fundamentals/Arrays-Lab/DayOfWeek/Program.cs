using System;

namespace DayOfWeek
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] daysInWeek = new string[] {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday"};

            int n = int.Parse(Console.ReadLine());

            if (n <= 0 || n >= 8)
            {
                Console.WriteLine("Invalid day!");
            }
            else
            {
                Console.WriteLine(daysInWeek[n - 1]);
            }
        }
    }
}