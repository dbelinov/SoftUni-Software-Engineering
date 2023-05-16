using System;

namespace WeddingSeats
{
    class Program
    {
        static void Main(string[] args)
        {
            char lastSector = char.Parse(Console.ReadLine());
            int rowsInFirstSector = int.Parse(Console.ReadLine());
            int placesOnOddRows = int.Parse(Console.ReadLine());

            int placesOnEvenRows = placesOnOddRows + 2;
            
            for (char i = 'A'; i <= lastSector; i++)
            {
                for (int row = 1; row <= rowsInFirstSector; row++)
                {
                    if (row % 2 != 0)
                    {
                        for (char places = 'a'; places <= placesOnOddRows; places++)
                        {
                            Console.Write($"{i}{row}{(char)places} ");
                        }
                    }
                    else
                    {
                        for (int places = 1; places <= placesOnEvenRows; places++)
                        {
                            Console.Write($"{i}{row}{(char)places} ");
                        }
                    }
                }
            }
        }
    }
}