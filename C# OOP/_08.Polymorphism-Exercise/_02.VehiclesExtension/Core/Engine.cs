using Vehicles.Core.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

namespace Vehicles.Core;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    public Engine(IWriter writer, IReader reader)
    {
        this.writer = writer;
        this.reader = reader;
    }
    public void Run()
    {
        string[] carTokens = reader.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IVehicle car = new Car(double.Parse(carTokens[1]), double.Parse(carTokens[2]));
        
        string[] truckTokens = reader.ReadLine()
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);
        IVehicle truck = new Truck(double.Parse(truckTokens[1]), double.Parse(truckTokens[2]));

        int commands = int.Parse(reader.ReadLine());
        
        for (int i = 0; i < commands; i++)
        {
            string[] tokens = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            try
            {
                if (tokens[0] == "Drive")
                {
                    if (tokens[1] == "Car")
                    {
                        writer.WriteLine(car.Drive(double.Parse(tokens[2])));
                    }
                    else
                    {
                        writer.WriteLine(truck.Drive(double.Parse(tokens[2])));
                    }
                }
                else
                {
                    if (tokens[1] == "Car")
                    {
                        car.Refuel(double.Parse(tokens[2]));
                    }
                    else
                    {
                        truck.Refuel(double.Parse(tokens[2]));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        writer.WriteLine($"Car: {car.FuelQuantity:f2}");
        writer.WriteLine($"Truck: {truck.FuelQuantity:f2}");
    }
}