using System;

namespace _02.NumbersBackwards
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; n--)
            {
                Console.WriteLine(n);
            }
        }
    }
}
