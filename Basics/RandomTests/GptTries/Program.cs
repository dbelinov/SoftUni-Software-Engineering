using System;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        int value = 0;
        bool allEqual = true;
        int maxDiff = 0;
        int prevPairValue = 0;
        for (int i = 0; i < n; i++)
        { 
            int num1 = int.Parse(Console.ReadLine());
            int num2 = int.Parse(Console.ReadLine());

            int pairValue = num1 + num2;
            if (i == 0)
            {
                value = pairValue;
            }
            else if (pairValue != value)
            {
                allEqual = false;
                int diff = Math.Abs(pairValue - prevPairValue);
                if (diff > maxDiff)
                {
                    maxDiff = diff;
                }
            }
            prevPairValue = pairValue;
        }

        if (allEqual)
        {
            Console.WriteLine("Yes, value={0}", value);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxDiff);
        }
    }
}
