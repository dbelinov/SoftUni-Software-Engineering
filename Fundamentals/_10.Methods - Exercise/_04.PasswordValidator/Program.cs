using System;
using System.ComponentModel;

namespace _04.PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            bool lengthMet = CheckLengthRequirement(password);
            bool containsOnlyLettersAndNums = CheckTypography(password);
            bool has2Numbers = CheckForNumberRequirement(password);
            
            if (!lengthMet)
                Console.WriteLine("Password must be between 6 and 10 characters");
            if (!containsOnlyLettersAndNums)
                Console.WriteLine("Password must consist only of letters and digits");
            if (!has2Numbers)
                Console.WriteLine("Password must have at least 2 digits");
            
            if (lengthMet && containsOnlyLettersAndNums && has2Numbers)
                Console.WriteLine("Password is valid");
        }

        private static bool CheckForNumberRequirement(string password)
        {
            int digitsCount = 0;

            foreach (var symbol in password)
            {
                if (symbol >= 48 && symbol <= 57)
                    digitsCount++;
            }
            if (digitsCount < 2)
                return false;
            return true;
        }

        private static bool CheckTypography(string password)
        {
            foreach (var symbol in password)
            {
                if (symbol >= 48 && symbol <= 57 ||
                    symbol >= 65 && symbol <= 90 ||
                    symbol >= 97 && symbol <= 122)
                {
                    continue;
                }
                else
                {
                    return false;
                }
            }

            return true;
        }

        private static bool CheckLengthRequirement(string password)
        {
            if (password.Length >= 6 && password.Length <= 10)
                return true;
            return false;
        }
    }
}