using System;
using System.Collections.Generic;
using System.Linq;

/*
Car/Audi/A3/110
Car/Maserati/Levante/350
Truck/Mercedes/Actros/9019
Car/Porsche/Panamera/375
end

Car/Subaru/Impreza/152
Car/Peugeot/307/109
end
*/
namespace _07.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            List<Truck> trucks = new List<Truck>();
            
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split('/');
                string type = tokens[0];
                string brand = tokens[1];
                string model = tokens[2];
                int weightOrHp = int.Parse(tokens[3]);
                if (type == "Car")
                {
                    Car car = new Car(brand, model, weightOrHp);
                    cars.Add(car);
                }
                else if(type == "Truck")
                {
                    Truck truck = new Truck(brand, model, weightOrHp);
                    trucks.Add(truck);
                }
            }

            List<Car> filteredCars = new List<Car>();
            List<Truck> filteredTrucks = new List<Truck>();
            if (cars.Count > 0)
            {
                filteredCars = cars.OrderBy(x => x.Brand).ToList();
            }

            if (trucks.Count > 0)
            {
                filteredTrucks = trucks.OrderBy(x => x.Brand).ToList();
            }

            if (filteredCars.Count > 0)
            {
                Console.WriteLine("Cars:");
                foreach (Car car in filteredCars)
                {
                    Console.WriteLine(car);
                }
            }

            if (filteredTrucks.Count > 0)
            {
                Console.WriteLine("Trucks:");
                foreach (Truck truck in filteredTrucks)
                {
                    Console.WriteLine(truck);
                }
            }
        }
    }

    class Truck
    {
        public Truck(string brand, string model, int weight)
        {
            Brand = brand;
            Model = model;
            Weight = weight;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int Weight { get; set; }


        public override string ToString()
        {
            return $"{Brand}: {Model} - {Weight}kg";
        }
    }

    class Car
    {
        public Car(string brand, string model, int horsePower)
        {
            Brand = brand;
            Model = model;
            HorsePower = horsePower;
        }

        public string Brand { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }

        public override string ToString()
        {
            return $"{Brand}: {Model} - {HorsePower}hp";
        }
    }
}