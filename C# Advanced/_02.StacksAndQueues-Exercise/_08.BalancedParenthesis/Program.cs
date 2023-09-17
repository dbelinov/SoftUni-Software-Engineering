using System;
using System.Collections.Generic;

namespace _08.BalancedParenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Stack<char> opening = new Stack<char>();

            foreach (char item in input)
            {
                if (item == '(' || item == '{' || item == '[')
                {
                    opening.Push(item);
                }

                if (opening.Count == 0)
                {
                    opening.Push(item);
                    break;
                }
                
                if ((item == ')' && opening.Peek() == '(') 
                    || (item == '}' && opening.Peek() == '{') 
                    || (item == ']' && opening.Peek() == '['))
                {
                    opening.Pop();
                }
            }

            if (opening.Count > 0)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}