using System;

namespace _02.ReportSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int expectedMoney = int.Parse(Console.ReadLine());

            int collectedMoney = 0;
            int counter = 1;
            string typeOfTransaction = "";
            double CS = 0;
            int counterCS = 0;
            double CC = 0;
            int counterCC = 0;


            while (collectedMoney < expectedMoney)
            {
                string input = Console.ReadLine();
                if (input == "End") break;
                int costOfItem = int.Parse(input);

                if (counter % 2 != 0)
                {
                    typeOfTransaction = "Cash";
                }
                else
                {
                    typeOfTransaction = "Card";
                }

                if ((costOfItem > 100 && typeOfTransaction == "Cash") || (costOfItem < 10 && typeOfTransaction == "Card"))
                {
                    Console.WriteLine("Error in transaction!");
                    counter++;
                    continue;
                }
                else
                {
                    Console.WriteLine("Product sold!");
                    collectedMoney += costOfItem;

                    if (typeOfTransaction == "Cash")
                    {
                        CS += costOfItem;
                        counterCS++;
                    }
                    else
                    {
                        CC += costOfItem;
                        counterCC++;
                    }
                }
                counter++;
            }

            if (collectedMoney >= expectedMoney)
            {
                Console.WriteLine($"Average CS: {CS / counterCS:f2}");
                Console.WriteLine($"Average CC: {CC / counterCC:f2}");
            }
            else
            {
                Console.WriteLine("Failed to collect required money for charity.");
            }
        }
    }
}
