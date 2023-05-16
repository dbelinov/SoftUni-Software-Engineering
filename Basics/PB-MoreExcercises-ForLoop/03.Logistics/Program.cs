using System;

namespace _03.Logistics
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int cargoAmount = int.Parse(Console.ReadLine());

            double totalCargo = 0;
            double averagePerCarry = 0;
            double pricePerTon = 0;
            double totalPrice = 0;
            int cargoWeight = 0;
            string typeOfCarry = "";
            int amountMicrobus = 0;
            int amountTruck = 0;
            int amountTrain = 0;

            for (int i = 0; i < cargoAmount; i++)
            {
                cargoWeight = int.Parse(Console.ReadLine());

                totalCargo += cargoWeight;
                
                if(cargoWeight <= 3)
                {
                    typeOfCarry = "microbus";
                    pricePerTon = 200;
                    amountMicrobus += cargoWeight;
                }
                else if(cargoWeight <= 11)
                {
                    typeOfCarry = "truck";
                    pricePerTon = 175;
                    amountTruck += cargoWeight;
                }
                else
                {
                    typeOfCarry = "train";
                    pricePerTon = 120;
                    amountTrain += cargoWeight;
                }

                totalPrice += cargoWeight * pricePerTon;
            }
            averagePerCarry = totalPrice / totalCargo;

            double percentageMicrobus = amountMicrobus / totalCargo * 100;
            double percentageTruck = amountTruck / totalCargo * 100;
            double percentageTrain = amountTrain / totalCargo * 100;

            Console.WriteLine($"{averagePerCarry:f2}");
            Console.WriteLine($"{percentageMicrobus:f2}%");
            Console.WriteLine($"{percentageTruck:f2}%");
            Console.WriteLine($"{percentageTrain:f2}%");
        }
    }
}
