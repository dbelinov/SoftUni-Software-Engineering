using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.NeedForSpeed3
{
    class Car
    {
        public Car(string name, int mileage, int fuel)
        {
            Name = name;
            Mileage = mileage;
            Fuel = fuel;
        }

        public string Name { get; set; }
        public int Mileage { get; set; }
        public int Fuel { get; set; }

        public override string ToString()
        {
            return $"{Name} -> Mileage: {Mileage} kms, Fuel in the tank: {Fuel} lt.";
        }
    }
    
    class Program
    {
        static void Main()
        {
            int numberOfCars = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>(); 
            for (int i = 0; i < numberOfCars; i++)
            {
                string carInfo = Console.ReadLine();
                string[] tokens = carInfo.Split('|');
                string name = tokens[0];
                int mileage = int.Parse(tokens[1]);
                int fuel = int.Parse(tokens[2]);
                Car car = new Car(name, mileage, fuel);
                cars.Add(car);
            }

            string command;
            while ((command = Console.ReadLine()) != "Stop")
            {
                string[] arguments = command.Split(" : ");
                switch (arguments[0])
                {
                    case "Drive":
                        string carName = arguments[1];
                        int distance = int.Parse(arguments[2]);
                        int neededFuel = int.Parse(arguments[3]);
                        Car neededCar = cars.Find(x => x.Name == carName);
                        if (neededCar.Fuel <= neededFuel)
                        {
                            Console.WriteLine($"Not enough fuel to make that ride");   
                        }
                        else
                        {
                            neededCar.Mileage += distance;
                            neededCar.Fuel -= neededFuel;
                            Console.WriteLine($"{neededCar.Name} driven for {distance} kilometers. {neededFuel} liters of fuel consumed.");
                        }

                        if (neededCar.Mileage >= 100000)
                        {
                            Console.WriteLine($"Time to sell the {neededCar.Name}!");
                            cars.Remove(neededCar);
                        }
                        break;
                    case "Refuel":
                        string carToRefuel = arguments[1];
                        int fuelAmount = int.Parse(arguments[2]);
                        Car refueledCar = cars.Find(car => car.Name == carToRefuel);
                        int startingFuel = refueledCar.Fuel;
                        refueledCar.Fuel += fuelAmount;
                        int fuelAdded;
                        if (refueledCar.Fuel > 75)
                        {
                            refueledCar.Fuel = 75;
                            fuelAdded = 75 - startingFuel;
                        }
                        else
                        {
                            fuelAdded = fuelAmount;
                        }

                        Console.WriteLine($"{carToRefuel} refueled with {fuelAdded} liters");
                        break;
                    case "Revert":
                        string carToRevert = arguments[1];
                        int kilometres = int.Parse(arguments[2]);
                        Car revertedCar = cars.Find(car => car.Name == carToRevert);
                        revertedCar.Mileage -= kilometres;
                        if (revertedCar.Mileage < 10000)
                        {
                            revertedCar.Mileage = 10000;
                        }
                        else
                        {
                            Console.WriteLine($"{carToRevert} mileage decreased by {kilometres} kilometers");
                        }
                        break;
                }
            }

            foreach (Car car in cars)
            {
                Console.WriteLine(car);
            }
        }
    }
}