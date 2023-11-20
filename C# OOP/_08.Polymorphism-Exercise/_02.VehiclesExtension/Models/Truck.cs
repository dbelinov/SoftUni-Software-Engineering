using Vehicles.Models.Interfaces;

namespace Vehicles.Models;

public class Truck : Vehicle
{
    private const double ConsumptionIncrease = 1.6;
    
    public Truck(double fuelQuantity, double fuelConsumption) : base(fuelQuantity, fuelConsumption, ConsumptionIncrease)
    {
    }
    
    public override void Refuel(double fuel)
    {
        base.Refuel(fuel * 0.95);
    }
}