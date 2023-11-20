using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double increasedConsumption;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption)
    {
        FuelQuantity = fuelQuantity;
        this.increasedConsumption = increasedConsumption;
        FuelConsumption = fuelConsumption + increasedConsumption;
    }

    public double FuelQuantity { get; private set; }
    public double FuelConsumption { get; private set; }

    public string Drive(double distance)
    {
        if (FuelQuantity - distance * FuelConsumption < 0)
        {
            throw new ArgumentException($"{GetType().Name} needs refueling");
        }

        FuelQuantity -= distance * FuelConsumption;
        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double fuel) => FuelQuantity += fuel;
    
    public override string ToString()
        => $"{GetType().Name}: {FuelQuantity:F2}";
}