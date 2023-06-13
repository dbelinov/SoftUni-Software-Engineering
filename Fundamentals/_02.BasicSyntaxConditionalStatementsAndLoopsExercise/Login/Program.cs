using System;
using Microsoft.VisualBasic;

namespace Login
{
    class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            char[] stringArray = username.ToCharArray();
            Array.Reverse(stringArray);
            string password = new string(stringArray);
            
            int tries = 0;

            while (tries < 4)
            {
                string input = Console.ReadLine();
                if (input == password)
                {
                    Console.WriteLine($"User {username} logged in.");
                    break;
                }
                else  if (tries < 3) Console.WriteLine("Incorrect password. Try again.");

                tries++;
            }

            if (tries == 4) Console.WriteLine($"User {username} blocked!");
            
        }
    }
}