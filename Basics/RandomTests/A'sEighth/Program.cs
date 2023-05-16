using System;

namespace ConsoleApp18
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;
            int sum4 = 0;
            int maxDiff = 0;
            bool AllEqual = true;

            for (int i = 0; i < n && n % 2 != 0; i ++)
            { 
                int currentSum1 = int.Parse(Console.ReadLine());
                int currentSum2 = int.Parse(Console.ReadLine());
                int currentDiff = Math.Abs(currentSum1 + currentSum2 - sum1 - sum2);
                sum1 = currentSum1;
                sum2 = currentSum2;

                if (currentDiff > maxDiff)
                {
                    maxDiff = currentDiff;
                }
                if (currentSum1 + currentSum2 != sum1 + sum2)
                {
                    AllEqual = false;
                }
            }

            for (int i = 0; i < n && n % 2 == 0; i ++)
            {
                
                int currentSum1 = int.Parse(Console.ReadLine());
                int currentSum2 = int.Parse(Console.ReadLine());
                int currentDiff = Math.Abs(currentSum1 + currentSum2 - sum1 - sum2);
                sum3 = currentSum1;
                sum4 = currentSum2;

                if (currentDiff > maxDiff)
                {
                    maxDiff = currentDiff;
                }
                if (currentSum1 + currentSum2 != sum1 + sum2)
                {
                    AllEqual = false;
                }
            }

                if (AllEqual)
            {
                Console.WriteLine("Yes,value={0}", sum1 + sum2);
            }
            else
            {
                Console.WriteLine("No, maxDiff={0}", maxDiff);
            }



        }
    }
}