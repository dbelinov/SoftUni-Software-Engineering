using System;

namespace _12.TradeCommissions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sale = double.Parse(Console.ReadLine());

            double sum = 0;

            switch (city)
            {
                case "Sofia":
                    if (sale >= 0 && sale <= 500)
                    {
                        sum = 0.05 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else if (sale > 500 && sale <= 1000)
                    {
                        sum = 0.07 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else if (sale > 1000 && sale <= 10000)
                    {
                        sum = 0.08 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else if (sale > 10000)
                    {
                        sum = 0.12 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                  break;
                
                    case "Varna":
                    if (sale >= 0 && sale <= 500)
                    {
                        sum = 0.045 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else if (sale > 500 && sale <= 1000)
                    {
                        sum = 0.075 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else if (sale > 1000 && sale <= 10000)
                    {
                        sum = 0.1 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else if (sale > 10000)
                    {
                        sum = 0.13 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                  break;
                
                    case "Plovdiv":
                    if (sale >= 0 && sale <= 500)
                    {
                        sum = 0.055 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else if (sale > 500 && sale <= 1000)
                    {
                        sum = 0.08 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else if (sale > 1000 && sale <= 10000)
                    {
                        sum = 0.12 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else if (sale > 10000)
                    {
                        sum = 0.145 * sale;
                        Console.WriteLine($"{sum:F2}");
                    }
                    else
                    {
                        Console.WriteLine("error");
                    }
                  break;
                default:
                    Console.WriteLine("error");
                    break;
            }
        }
    }
}
