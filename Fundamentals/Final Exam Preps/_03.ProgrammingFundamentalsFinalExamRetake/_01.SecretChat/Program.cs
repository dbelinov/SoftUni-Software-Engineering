using System;
using System.Linq;
using Microsoft.VisualBasic;

namespace _01.SecretChat
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = Console.ReadLine();
            string instruction;
            while ((instruction = Console.ReadLine()) != "Reveal")
            {
                string[] tokens = instruction.Split(":|:");
                switch (tokens[0])
                {
                    case "InsertSpace":
                        int insertIndex = int.Parse(tokens[1]);
                        message = message.Insert(insertIndex, " ");
                        break;
                    case "Reverse":
                        string substring = tokens[1];
                        if (message.Contains(substring))
                        {
                            int indexOfString = message.IndexOf(substring);
                            message = message.Remove(indexOfString, substring.Length);
                            substring = ReverseString(substring);
                            message += substring;
                        }
                        else
                        {
                            Console.WriteLine("error");
                            continue;
                        }
                        break;
                    case "ChangeAll":
                        string changeString = tokens[1];
                        string replacement = tokens[2];
                        message = message.Replace(changeString, replacement);
                        break;
                }

                Console.WriteLine(message);
            }

            Console.WriteLine($"You have a new text message: {message}");
        }

        public static string ReverseString(string substring)
        {
            char[] stringAsArr = substring.ToCharArray();
            stringAsArr = stringAsArr.Reverse().ToArray();
            string newString = new string(stringAsArr);
            return newString;
        }
    }
}