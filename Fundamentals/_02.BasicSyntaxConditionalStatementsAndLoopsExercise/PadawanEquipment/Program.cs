using System;

namespace PadawanEquipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double money = double.Parse(Console.ReadLine());
            int students = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double lightsabers = Math.Ceiling(students * 1.1);
            int robes = students;
            int belts = students - students / 6;

            double cost = lightsabers * lightsaberPrice + robes * robePrice + belts * beltPrice;

            if (money >= cost)
            {
                Console.WriteLine($"The money is enough - it would cost {cost:f2}lv.");
            }
            else
            {
                double neededMoney = cost - money;
                Console.WriteLine($"John will need {neededMoney:f2}lv more.");
            }
        }
    }
}