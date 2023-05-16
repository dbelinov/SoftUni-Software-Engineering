using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace _06.OperationsBetweenNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            string symbol = Console.ReadLine();

            double sum = 0;
            double minus = 0;
            double multi = 0;
            double divided = 0;
            double moduled = 0;

            if (symbol == "+")
            {
                sum = number1 + number2;
                if (sum % 2 == 0)
                {
                    Console.WriteLine($"{number1} {symbol} {number2} = {sum} - even");
                }
                else
                {
                    Console.WriteLine($"{number1} {symbol} {number2} = {sum} - odd");
                }
            }
            else if (symbol == "-")
            {
                minus = number1 - number2;
                if(minus % 2 == 0)
                {
                    Console.WriteLine($"{number1} {symbol} {number2} = {minus} - even");
                }
                else
                {
                    Console.WriteLine($"{number1} {symbol} {number2} = {minus} - odd");
                }
            }
            else if (symbol == "*")
            {
                multi = number1 * number2;
                if (multi % 2 == 0)
                {
                    Console.WriteLine($"{number1} {symbol} {number2} = {multi} - even");
                }
                else
                {
                    Console.WriteLine($"{number1} {symbol} {number2} = {multi} - odd");
                }
            }
            else if (symbol == "/")
            {
                if (number2 != 0)
                {
                    divided = number1 / number2;
                    Console.WriteLine($"{number1} {symbol} {number2} = {divided:F2}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {number1} by zero");
                }
            }
            else if (symbol == "%")
            {
                if (number2 != 0)
                {
                    moduled = number1 % number2;
                    Console.WriteLine($"{number1} {symbol} {number2} = {moduled}");
                }
                else
                {
                    Console.WriteLine($"Cannot divide {number1} by zero");
                }
            }
        }
    }
}