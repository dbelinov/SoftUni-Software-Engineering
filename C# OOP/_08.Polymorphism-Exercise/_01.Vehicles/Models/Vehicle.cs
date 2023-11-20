using Vehicles.Exceptions;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public abstract class Vehicle : IVehicle
{
    private double increasedConsumption;

    protected Vehicle(double fuelQuantity, double fuelConsumption, double increasedConsumption, double tankCapacity)
    {
        if (fuelQuantity > tankCapacity)
        {
            FuelQuantity = 0;
        }
        else
        {
            FuelQuantity = fuelQuantity;
        }
        this.increasedConsumption = increasedConsumption;
        FuelConsumption = fuelConsumption;
        TankCapacity = tankCapacity;
    }

    public double FuelQuantity { get; private set; }
    public double FuelConsumption { get; private set; }
    public double TankCapacity { get; private set; }

    public string Drive(double distance, bool isIncreasedConsumption = true)
    {
        double consumption = isIncreasedConsumption
            ? FuelConsumption + increasedConsumption
            : FuelConsumption;

        if (FuelQuantity < distance * consumption)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.NotEnoughFuel, GetType().Name));
        }

        FuelQuantity -= distance * consumption;

        return $"{GetType().Name} travelled {distance} km";
    }

    public virtual void Refuel(double fuel)
    {
        if (fuel <= 0)
        {
            throw new ArgumentException(ExceptionMessages.InvalidFuelAmount);
        }
        
        if (FuelQuantity + fuel > TankCapacity)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.ExceededFuelAmount, fuel));
        }

        FuelQuantity += fuel;
    }
    
    public override string ToString()
        => $"{GetType().Name}: {FuelQuantity:F2}";
}