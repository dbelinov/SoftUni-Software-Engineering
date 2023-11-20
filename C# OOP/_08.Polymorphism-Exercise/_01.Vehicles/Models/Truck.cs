using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public class Truck : Vehicle
{
    private const double ConsumptionIncrease = 1.6;
    public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption, ConsumptionIncrease, tankCapacity)
    {
    }
    
    public override void Refuel(double amount)
    {
        if (amount + FuelQuantity > TankCapacity)
        {
            throw new ArgumentException($"Cannot fit {amount} fuel in the tank");
        }

        base.Refuel(amount * 0.95);
    }

}