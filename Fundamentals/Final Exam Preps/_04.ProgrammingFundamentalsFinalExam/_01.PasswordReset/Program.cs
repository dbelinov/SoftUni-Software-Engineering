using System;
using System.Text;

namespace _01.PasswordReset
{
    class Program
    {
        static void Main(string[] args)
        {
            string startPassword = Console.ReadLine();
            StringBuilder password = new StringBuilder(startPassword);

            string command;
            while ((command = Console.ReadLine()) != "Done")
            {
                string[] tokens = command.Split();
                switch (tokens[0])
                {
                    case "TakeOdd":
                        password = TakeOdd(password);
                        break;
                    case "Cut":
                        int index = int.Parse(tokens[1]);
                        int length = int.Parse(tokens[2]);
                        password.Remove(index, length);
                        Console.WriteLine(password.ToString());
                        break;
                    case "Substitute":
                        string substring = tokens[1];
                        string substitute = tokens[2];
                        if (password.ToString().Contains(substring))
                        {
                            password.Replace(substring, substitute);
                        }
                        else
                        {
                            Console.WriteLine("Nothing to replace!");
                            continue;
                        }

                        Console.WriteLine(password.ToString());
                        break;
                }
            }

            Console.WriteLine($"Your password is: {password}");
        }

        private static StringBuilder TakeOdd(StringBuilder password)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 1; i < password.Length; i += 2)
            {
                sb.Append(password[i]);
            }

            password = sb;
            Console.WriteLine(password);
            return password;
        }
    }
}