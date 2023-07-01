using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Threading.Tasks.Dataflow;
using System.Xml;

/*
truck Man red 200
truck Mercedes blue 300
car Ford green 120
car Ferrari red 550
car Lamborghini orange 570
End
Ferrari
Ford
Man
Close the Catalogue
*/
namespace _06.VehicleCatalogue
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();
                string typeOfVehicle = tokens[0];
                string model = tokens[1];
                string color = tokens[2];
                int horsePower = int.Parse(tokens[3]);

                Vehicle vehicle = new Vehicle(typeOfVehicle, model, color, horsePower);
                vehicles.Add(vehicle);
            }

            while ((input = Console.ReadLine()) != "Close the Catalogue")
            {
                string vehicleModel = input;
                Vehicle found = vehicles.FirstOrDefault(vehicle => vehicle.Model == vehicleModel);
                if (found != null)
                {
                    Console.WriteLine(found);                
                }
            }

            double averageHPCars = vehicles
                .Where(vehicle => vehicle.Type == "car")
                .Select(vehicle => vehicle.HorsePower)
                .DefaultIfEmpty()
                .Average();
            double averageHPTrucks = vehicles
                .Where(vehicle => vehicle.Type == "truck")
                .Select(vehicle => vehicle.HorsePower)
                .DefaultIfEmpty()
                .Average();

            Console.WriteLine($"Cars have average horsepower of: {averageHPCars:f2}.");
            Console.WriteLine($"Trucks have average horsepower of: {averageHPTrucks:f2}.");
        }
    }

    class Vehicle
    {
        public Vehicle(string type, string model, string color, int horsePower)
        {
            Type = type;
            Model = model;
            Color = color;
            HorsePower = horsePower;
        }

        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public int HorsePower { get; set; }

        public string CapitalizeFirstLetter(string value)
        {
            char[] charArray = value.ToCharArray();
            if (char.IsLower(charArray[0]))
            {
                charArray[0] = char.ToUpper(charArray[0]);
            }

            return new string(charArray);
        }

        public override string ToString()
        {
            string output = "";
            output += $"Type: {CapitalizeFirstLetter(Type)}\n";
            output += $"Model: {Model}\n";
            output += $"Color: {Color}\n";
            output += $"Horsepower: {HorsePower}";
            return output;
        }
    }
}