using System;

namespace Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int people = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses = 0;
            if (people % capacity <= capacity && people % capacity != 0)
                courses = people / capacity + 1;
            else
            {
                courses = people / capacity;
            }

            Console.WriteLine(courses);
        }
    }
}