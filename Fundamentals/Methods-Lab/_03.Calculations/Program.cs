using System;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string operation = Console.ReadLine();
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());

            switch (operation)
            {
                case "add":
                    AddOperation(firstNumber, secondNumber);
                    break;
                case "multiply":
                    MultiplicationOperation(firstNumber, secondNumber);
                    break;
                case "subtract":
                    SubtractingOperation(firstNumber, secondNumber);
                    break;
                case "divide":
                    DividingOperation(firstNumber, secondNumber);
                    break;
            }
        }

        static void DividingOperation(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber / secondNumber);
        }

        static void SubtractingOperation(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber - secondNumber);
        }

        static void MultiplicationOperation(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber * secondNumber);
        }

        static void AddOperation(int firstNumber, int secondNumber)
        {
            Console.WriteLine(firstNumber + secondNumber);
        }
    }
}