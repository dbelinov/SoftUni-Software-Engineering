using System;

namespace _04.VacationBooksList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int amount = int.Parse(Console.ReadLine());
            int pagesAnHour = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            int hours = amount / pagesAnHour / days;

            Console.WriteLine(hours);
        }
    }
}
