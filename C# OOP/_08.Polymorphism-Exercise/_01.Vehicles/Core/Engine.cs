using Vehicles.Core.Interfaces;
using Vehicles.Factories.Interfaces;
using Vehicles.IO.Interfaces;
using Vehicles.Models;
using Vehicles.Models.Interfaces;

/*
Car 30 0,04 70
   Truck 100 0,5 300
   Bus 40 0,3 150
   8
   Refuel Car -10
   Refuel Truck 0
   Refuel Car 10
   Refuel Car 300
   Drive Bus 10
   Refuel Bus 1000
   DriveEmpty Bus 100
   Refuel Truck 1000
   */

namespace Vehicles.Core;

public class Engine : IEngine
{
    private readonly IReader reader;
    private readonly IWriter writer;
    private readonly IVehicleFactory vehicleFactory;

    private readonly ICollection<IVehicle> vehicles;

    public Engine(IReader reader, IWriter writer, IVehicleFactory vehicleFactory)
    {
        this.reader = reader;
        this.writer = writer;
        this.vehicleFactory = vehicleFactory;

        vehicles = new List<IVehicle>();
    }

    public void Run()
    {
        vehicles.Add(CreateVehicle()); //add Car
        vehicles.Add(CreateVehicle()); //add Truck
        vehicles.Add(CreateVehicle()); //add Bus

        int commandsCount = int.Parse(reader.ReadLine());

        for (int i = 0; i < commandsCount; i++)
        {
            try
            {
                ProcessCommand();
            }
            catch (ArgumentException ex)
            {
                writer.WriteLine(ex.Message);
            }
            catch (Exception)
            {
                throw;
            }
        }

        foreach (var vehicle in vehicles)
        {
            writer.WriteLine(vehicle.ToString());
        }
    }

    private void ProcessCommand()
    {
        string[] commandTokens = reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

        string command = commandTokens[0];
        string vehicleType = commandTokens[1];

        IVehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == vehicleType);

        if (vehicle == null)
        {
            throw new ArgumentException("Invalid vehicle type");
        }

        if (command == "Drive")
        {
            double distance = double.Parse(commandTokens[2]);
            writer.WriteLine(vehicle.Drive(distance, true));
        }
        else if (command == "DriveEmpty")
        {
            double distance = double.Parse(commandTokens[2]);
            writer.WriteLine(vehicle.Drive(distance, false));
        }
        else if (command == "Refuel")
        {
            double fuelAmount = double.Parse(commandTokens[2]);
            vehicle.Refuel(fuelAmount);
        }
    }
    private IVehicle CreateVehicle()
    {
        string[] tokens = reader.ReadLine().Split(" ", System.StringSplitOptions.RemoveEmptyEntries);

        return vehicleFactory.Create(tokens[0], double.Parse(tokens[1]), double.Parse(tokens[2]), double.Parse(tokens[3]));
    }
}