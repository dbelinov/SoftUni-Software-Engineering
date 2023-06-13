using System;
using System.Net.Mail;

namespace SortNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double number1 = double.Parse(Console.ReadLine());
            double number2 = double.Parse(Console.ReadLine());
            double number3 = double.Parse(Console.ReadLine());

            double biggest = double.MinValue;
            double secondBiggest = double.MinValue;
            double thirdBiggest = double.MinValue;

            if (number1 > number2 && number1 > number3)
            {
                if (number2 > number3)
                {
                    biggest = number1;
                    secondBiggest = number2;
                    thirdBiggest = number3;
                }
                else
                {
                    biggest = number1;
                    secondBiggest = number3;
                    thirdBiggest = number2;
                }
            }
            else if (number2 > number1 && number2 > number3)
            {
                if (number1 > number3)
                {
                    biggest = number2;
                    secondBiggest = number1;
                    thirdBiggest = number3;
                }
                else
                {
                    biggest = number2;
                    secondBiggest = number3;
                    thirdBiggest = number1;
                }
            }
            else if (number3 > number1 && number3 > number2)
            {
                if (number2 > number1)
                {
                    biggest = number3;
                    secondBiggest = number2;
                    thirdBiggest = number1;
                }
                else
                {
                    biggest = number3;
                    secondBiggest = number1;
                    thirdBiggest = number2;
                }
            }

            Console.WriteLine(biggest);
            Console.WriteLine(secondBiggest);
            Console.WriteLine(thirdBiggest);

        }
    }
}