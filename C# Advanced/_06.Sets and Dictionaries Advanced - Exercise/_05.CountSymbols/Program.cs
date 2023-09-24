using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.CountSymbols
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] symbols = Console.ReadLine().ToCharArray();

            Dictionary<char, int> symbolDict = new Dictionary<char, int>();

            foreach (char symbol in symbols)
            {
                if (!symbolDict.ContainsKey(symbol))
                {
                    symbolDict.Add(symbol, 0);
                }

                symbolDict[symbol]++;
            }

            foreach (var symbolPair in symbolDict.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{symbolPair.Key}: {symbolPair.Value} time/s");
            }
        }
    }
}