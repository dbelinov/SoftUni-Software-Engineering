using System;
using System.Collections.Generic;

/*
8
1 abc
3 3
2 3
1 xy
3 2
4
4
3 1
*/

namespace _09.SImpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = string.Empty;
            int commands = int.Parse(Console.ReadLine());
            Stack<string> undo = new Stack<string>();
            
            for (int i = 0; i < commands; i++)
            {
                string[] tokens = Console.ReadLine().Split();
                switch (tokens[0])
                {
                    case "1":
                        undo.Push(text);
                        text += tokens[1];
                        break;
                    case "2":
                        undo.Push(text);
                        int amountToErase = int.Parse(tokens[1]);
                        text = text.Substring(0, text.Length - amountToErase);
                        break;
                    case "3":
                        int index = int.Parse(tokens[1]);
                        Console.WriteLine(text[index - 1]);
                        break;
                    case "4":
                        text = undo.Pop();
                        break;
                }
            }
        }
    }
}