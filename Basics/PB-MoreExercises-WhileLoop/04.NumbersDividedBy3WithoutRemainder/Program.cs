﻿using System;

namespace _04.NumbersDividedBy3WithoutRemainder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                if(i % 3 == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}
