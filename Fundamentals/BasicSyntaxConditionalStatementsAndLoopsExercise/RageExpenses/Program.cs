using System;

namespace RageExpenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int lostGames = int.Parse(Console.ReadLine());
            float headsetPrice = float.Parse(Console.ReadLine());
            float mousePrice = float.Parse(Console.ReadLine());
            float keyboardPrice = float.Parse(Console.ReadLine());
            float displayPrice = float.Parse(Console.ReadLine());

            int brokenHeadsets = 0;
            int brokenMice = 0;
            int brokenKeyboardsInitial = 0;
            int brokenKeyboards = 0;
            int brokenDisplays = 0;
            bool brokenHeadset = false;
            bool brokenMouse = false;

            for (int game = 1; game <= lostGames; game++)
            {
                if (game % 2 == 0)
                {
                    brokenHeadset = true;
                    brokenHeadsets++;
                }

                if (game % 3 == 0)
                {
                    brokenMouse = true;
                    brokenMice++;
                }

                if (brokenHeadset && brokenMouse && game % 6 == 0)
                {
                    brokenKeyboardsInitial++;
                    brokenHeadset = false;
                    brokenMouse = false;
                }

                if (brokenKeyboardsInitial != brokenKeyboards && brokenKeyboardsInitial % 2 == 0 && brokenKeyboardsInitial > 0)
                {
                    brokenDisplays++;
                }

                brokenKeyboards = brokenKeyboardsInitial;
            }

            float cost = brokenDisplays * displayPrice + brokenHeadsets * headsetPrice +
                         brokenKeyboards * keyboardPrice + brokenMice * mousePrice;
            
            Console.WriteLine($"Rage expenses: {cost:f2} lv.");
        }
    }
}