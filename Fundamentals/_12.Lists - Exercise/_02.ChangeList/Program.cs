using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;


/*
1 2 3 4 5 5 5 6
Delete 5
Insert 10 1 
Delete 5 
end
*/
namespace _02.ChangeList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> ints = Console
                .ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = "";
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split();
                if (tokens[0] == "Delete")
                {
                    int numberToBeDeleted = int.Parse(tokens[1]);
                    while (ints.Contains(numberToBeDeleted))
                    {
                        ints.Remove(numberToBeDeleted);
                    }
                }
                else if (tokens[0] == "Insert")
                {
                    int index = int.Parse(tokens[2]);
                    int element = int.Parse(tokens[1]);
                    ints.Insert(index, element);
                }
            }

            Console.WriteLine(string.Join(' ', ints));
        }
    }
}