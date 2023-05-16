using System;

namespace _05.Paycheck
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int salary = int.Parse(Console.ReadLine());
            int fee = 0;

            for (int i = 0; i < n && fee < salary; i++)
            {
                string site = Console.ReadLine();

                if (site == "Facebook")
                {
                    fee += 150;
                }
                else if (site == "Instagram")
                {
                    fee+= 100;
                }
                else if (site == "Reddit")
                {
                    fee += 50;
                }
            }

            if (fee >= salary)
            {
                Console.WriteLine("You have lost your salary.");
            }
            else
            {
                Console.WriteLine(salary - fee);
            }
        }
    }
}
