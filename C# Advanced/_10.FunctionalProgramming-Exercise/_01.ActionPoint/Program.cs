using System;

namespace _01.ActionPoint
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printer = words => Console.WriteLine(string.Join(Environment.NewLine, words));

            printer(strings);
        }
    }
}