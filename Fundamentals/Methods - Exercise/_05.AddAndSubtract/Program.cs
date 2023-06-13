using System;

namespace _05.AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInteger = int.Parse(Console.ReadLine());
            int secondInteger = int.Parse(Console.ReadLine());
            int thirdInteger = int.Parse(Console.ReadLine());

            int sumOfFirstTwoInts = SumOfFirstTwoInts(firstInteger, secondInteger);
            int result = SubtractThirdInt(sumOfFirstTwoInts, thirdInteger);
            Console.WriteLine(result);
        }

        private static int SubtractThirdInt(int sumOfFirstTwoInts, int thirdInteger)
        { 
            return sumOfFirstTwoInts - thirdInteger;
        }

        private static int SumOfFirstTwoInts(int firstInteger, int secondInteger)
        {
            return firstInteger + secondInteger;
        }
    }
}