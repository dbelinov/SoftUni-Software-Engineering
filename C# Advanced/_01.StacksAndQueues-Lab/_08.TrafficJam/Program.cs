using System;
using System.Collections.Generic;
using System.Linq;

/*
4
Hummer H2
Audi
Lada
Tesla
Renault
Trabant
Mercedes
MAN Truck
green
green
Tesla
Renault
Trabant
end
*/

namespace _08.TrafficJam
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Queue<string> traffic = new Queue<string>();

            int passedCars = 0;

            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if (input != "green")
                {
                    traffic.Enqueue(input);
                }
                else
                {
                    if (traffic.Count > 0)
                    {
                        for (int i = 0; i < n; i++)
                        {
                            if (i > traffic.Count)
                            {
                                break;
                            }
                            Console.WriteLine($"{traffic.Peek()} passed!");
                            traffic.Dequeue();
                            passedCars++;
                        }
                    }
                }
            }

            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}