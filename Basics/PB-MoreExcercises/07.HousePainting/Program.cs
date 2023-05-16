using System;

namespace _07.HousePainting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double houseHeight = double.Parse(Console.ReadLine());
            double wallLength = double.Parse(Console.ReadLine());
            double roofHeight = double.Parse(Console.ReadLine());

            double areaWallDoor = houseHeight * houseHeight - 1.2 * 2;
            double areaWallWindow = houseHeight * wallLength - 1.5 * 1.5;
            double backWall = houseHeight * houseHeight;
            double roofFirst = houseHeight * wallLength;
            double roofSecond = houseHeight * roofHeight / 2;

            double totalRoof = 2 * roofFirst + 2 * roofSecond;
            double totalHouse = areaWallDoor + backWall + 2 * areaWallWindow;

            double roofAmount = totalRoof / 4.3;
            double houseAmount = totalHouse / 3.4;

            Console.WriteLine($"{houseAmount:F2}");
            Console.WriteLine($"{roofAmount:F2}");
        }
    }
}
