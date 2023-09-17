using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.MatchingBrackets
{
    class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> openingBrackets = new Stack<int>();

            for (int i = 0; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    openingBrackets.Push(i);
                }

                if (expression[i] == ')')
                {
                    int startIndex = openingBrackets.Pop();
                    string latestExpression = expression.Substring(startIndex, i - startIndex + 1);
                    Console.WriteLine(latestExpression);
                }
            }
        }
    }
}