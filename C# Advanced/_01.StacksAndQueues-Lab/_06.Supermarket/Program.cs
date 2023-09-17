using System;
using System.Collections.Generic;
/*
Liam
Noah
James
Paid
Oliver
Lucas
Logan
Tiana
End
*/
namespace _06.Supermarket
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string person;
            while ((person = Console.ReadLine()) != "End")
            {
                if (person != "Paid")
                {
                    queue.Enqueue(person);
                }
                else
                {
                    foreach (string name in queue)
                    {
                        Console.WriteLine(name);
                    }
                    queue.Clear();
                }
            }

            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}