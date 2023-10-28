namespace DefiningClasses;

public class Car
{
    public Car(string model, double fuelAmount, double fuelConsumptionPerKilometer)
    {
        Model = model;
        FuelAmount = fuelAmount;
        FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
        TravelledDistance = 0;
    }

    public string Model { get; set; }
    private double FuelAmount { get; set; }
    private double FuelConsumptionPerKilometer { get; set; }
    public double TravelledDistance { get; set; }

    public void Drive(double amountOfKm)
    {
        double totalConsumption = amountOfKm * FuelConsumptionPerKilometer;
        if (CanDrive(amountOfKm, totalConsumption))
        {
            FuelAmount -= totalConsumption;
            TravelledDistance += amountOfKm;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
    
    private bool CanDrive(double amountOfKm, double totalConsumption)
    {
        if (totalConsumption <= FuelAmount)
        {
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return $"{Model} {FuelAmount:f2} {TravelledDistance}";
    }
}