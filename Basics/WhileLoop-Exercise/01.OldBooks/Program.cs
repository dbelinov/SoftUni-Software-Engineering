﻿using System;

namespace _01.OldBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string favouriteBook = Console.ReadLine();

            string input = Console.ReadLine();
            int bookCount = 0;
            while (input != "No More Books")
            {
                if (input == favouriteBook)
                {
                    Console.WriteLine($"You checked {bookCount} books and found it.");
                    return;
                }
                else
                {
                    bookCount++;
                    input = Console.ReadLine();
                }
            }
            Console.WriteLine("The book you search is not here!");
            Console.WriteLine($"You checked {bookCount} books.");
        }
    }
}
