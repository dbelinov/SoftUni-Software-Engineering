using System;

namespace _07.RepeatString
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int repeatTimes = int.Parse(Console.ReadLine());

            Console.WriteLine(RepeatedString(input, repeatTimes));
        }

        private static string RepeatedString(string input, int repeatTimes)
        {
            string repeatedString = "";
            for (int i = 0; i < repeatTimes; i++)
            {
                repeatedString += input;
            }

            return repeatedString;
        }
    }
}