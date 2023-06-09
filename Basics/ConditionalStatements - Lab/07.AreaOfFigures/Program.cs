﻿using System;

namespace _07.AreaOfFigures
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            
            if(type == "square")
            {
                double a = double.Parse(Console.ReadLine());
                double area = Math.Pow(a, 2);
                Console.WriteLine(area);
            }
            else if (type == "rectangle")
            {
                double a = double.Parse(Console.ReadLine());
                double b = double.Parse(Console.ReadLine());
                double area = a * b;
                Console.WriteLine(area);
            }
            else if (type == "circle")
            {
                double r = double.Parse(Console.ReadLine());
                double area = Math.PI * Math.Pow(r, 2);
                Console.WriteLine(area);
            }
            else if (type == "triangle")
            {
                double a = double.Parse(Console.ReadLine());
                double h = double.Parse(Console.ReadLine());
                double area = a * h / 2;
                Console.WriteLine(area);
            }

        }
    }
}
