using System;
using System.ComponentModel.Design.Serialization;

namespace _06.Substitute
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int k = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());

            int counter = 0;

            for (int i = k; i <= 8; i++)
            {
                if (i % 2 == 0)
                {
                    for (int i1 = 9; i1 >= l; i1--)
                    {
                        if (i1 % 2 != 0)
                        {
                            for (int i2 = m; i2 <= 8; i2++)
                            {
                                if (i2 % 2 == 0)
                                {
                                    for (int i3 = 9; i3 >= n; i3--)
                                    {
                                        if (i3 % 2 != 0)
                                        {
                                            if (i == i2 && i1 == i3)
                                            {
                                                Console.WriteLine("Cannot change the same player.");
                                                continue;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"{i}{i1} - {i2}{i3}");
                                                counter++;
                                                if (counter == 6) return;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
