using System;
using System.Collections.Generic;
using System.Linq;

/*
1 23 29 18 43 21 20
Add 5
Remove 5
Shift left 3
Shift left 1
End

5 12 42 95 32 1
Insert 3 0
Remove 10
Insert 8 6
Shift right 1
Shift left 2
End
*/

namespace _04.ListOperations
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

            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Add":
                        int numberToBeAdded = int.Parse(tokens[1]);
                        ints.Add(numberToBeAdded);
                        break;
                    case "Insert":
                        int numberToInsert = int.Parse(tokens[1]);
                        int insertIndex = int.Parse(tokens[2]);
                        if (insertIndex < ints.Count && insertIndex >= 0)
                        {
                            ints.Insert(insertIndex, numberToInsert);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }

                        break;
                    case "Remove":
                        int indexToRemove = int.Parse(tokens[1]);
                        if (indexToRemove < ints.Count && indexToRemove >= 0)
                        {
                            ints.RemoveAt(indexToRemove);
                        }
                        else
                        {
                            Console.WriteLine("Invalid index");
                        }
                        break;
                    case "Shift":
                        int amountToShift = int.Parse(tokens[2]);
                        if (tokens[1] == "left")
                        {
                            for (int i = 0; i < amountToShift; i++)
                            {
                                int firstNumber = ints[0];
                                ints.RemoveAt(0);
                                ints.Add(firstNumber);
                            }
                        }
                        else if (tokens[1] == "right")
                        {
                            for (int i = 0; i < amountToShift; i++)
                            {
                                int lastNumber = ints[ints.Count - 1];
                                ints.RemoveAt(ints.Count - 1);
                                ints.Insert(0,lastNumber);
                            }
                        }
                        break;
                }
            }

            Console.WriteLine(string.Join(' ', ints));
        }
    }
}