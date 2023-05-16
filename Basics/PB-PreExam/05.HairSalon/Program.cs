using System;

namespace _05.HairSalon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int targetForDay = int.Parse(Console.ReadLine());

            string input = "";
            int wonMoney = 0;

            while(wonMoney < targetForDay)
            {
                input = Console.ReadLine();

                if (input == "closed") break;

                string type = input;

                string typeOfDoing = Console.ReadLine();

                if (typeOfDoing == "mens")
                {
                    wonMoney += 15;
                }
                else if (typeOfDoing == "ladies")
                {
                    wonMoney += 20;
                }
                else if (typeOfDoing == "kids")
                {
                    wonMoney += 10;
                }
                else if (typeOfDoing == "touch up")
                {
                    wonMoney += 20;
                }
                else if (typeOfDoing == "full color")
                {
                    wonMoney += 30;
                }
 
            }

            if (wonMoney >= targetForDay)
            {
                Console.WriteLine("You have reached your target for the day!");
            }
            else
            {
                Console.WriteLine($"Target not reached! You need {targetForDay - wonMoney}lv. more.");
            }

            Console.WriteLine($"Earned money: {wonMoney}lv.");
        }
    }
}
