using System;

namespace CinemaVoucher
{
    class Program
    {
        static void Main(string[] args)
        {
            int voucher = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();
            int countMovieTickets = 0;
            int countProducts = 0;
            int price = 0;

            while (input != "End" && voucher > 0)
            {
                if (input.Length > 8)
                {
                    for (int i = 0; i <= 1; i++)
                    {
                         price= input[i];
                        if (price <= voucher)
                        voucher -= price;
                        else
                        {
                            Console.WriteLine(countMovieTickets);
                            Console.WriteLine(countProducts);
                            return;
                        }
                    }

                    countMovieTickets++;
                }
                else if (input.Length <= 8)
                {
                    price = input[0];
                    if (price <= voucher)
                        voucher -= price;
                    else
                    {
                        Console.WriteLine(countMovieTickets);
                        Console.WriteLine(countProducts);
                        return;
                    }
                    countProducts++;
                }
                input = Console.ReadLine();
            }

            Console.WriteLine(countMovieTickets);
            Console.WriteLine(countProducts);
        }
    }
}