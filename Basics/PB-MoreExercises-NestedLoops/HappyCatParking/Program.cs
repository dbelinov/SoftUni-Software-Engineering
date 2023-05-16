using System;

namespace HappyCatParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int hoursPerDay = int.Parse(Console.ReadLine());
            double sumForDay = 0;
            double totalSum = 0;
            for (int day = 1; day <= days; day++) {

                for (int hour = 1; hour <= hoursPerDay; hour++)
                {
                    if (day % 2 == 0 && hour % 2 != 0)
                    {
                        sumForDay += 2.50;
                    }
                    else if (day % 2 != 0 && hour % 2 == 0)
                    {
                        sumForDay += 1.25;
                    }
                    else
                    {
                        sumForDay += 1;
                    }
                }

                totalSum += sumForDay;
            Console.WriteLine($"Day: {day} - {sumForDay:f2} leva");
            sumForDay = 0;
            }
            Console.WriteLine($"Total: {totalSum:f2} leva");
        }
    }
}
