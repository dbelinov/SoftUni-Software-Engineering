using System;

namespace _11.MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            double firstNumber = double.Parse(Console.ReadLine());
            char operatorOfCalculation = char.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            Console.WriteLine(Calculation(firstNumber, operatorOfCalculation, secondNumber));
        }

        private static double Calculation(double firstNumber, char operatorOfCalculation, double secondNumber)
        {
            switch (operatorOfCalculation)
            {
                case '/':
                    return firstNumber / secondNumber;
                    break;
                case '*':
                    return firstNumber * secondNumber;
                break;
                case '+':
                    return firstNumber + secondNumber;
                    break;
                case '-':
                    return firstNumber - secondNumber;
                    break;
            }

            return 0;
        }
    }
}