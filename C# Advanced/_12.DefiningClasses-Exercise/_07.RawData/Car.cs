namespace DefiningClasses;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public Tyre[] Tires { get; set; }

    public Car()
    {
        Engine = new Engine();
        Cargo = new Cargo();
        Tyre tire1 = new();
        Tyre tire2 = new();
        Tyre tire3 = new();
        Tyre tire4 = new();
        Tires = new[] {tire1, tire2, tire3, tire4};
    }

    public Car(string model, int engineSpeed, int enginePower, int cargoWeight, string cargoType, double tire1Pressure, int tire1Age, double tire2Pressure, int tire2Age, double tire3Pressure, int tire3Age, double tire4Pressure, int tire4Age) : this()
    {
        Model = model;
        Engine.Speed = engineSpeed;
        Engine.Power = enginePower;
        Cargo.Weight = cargoWeight;
        Cargo.Type = cargoType;
        Tires[0].Pressure = tire1Pressure;
        Tires[0].Age = tire1Age;
        Tires[1].Pressure = tire2Pressure;
        Tires[1].Age = tire2Age;
        Tires[2].Pressure = tire3Pressure;
        Tires[2].Age = tire3Age;
        Tires[3].Pressure = tire4Pressure;
        Tires[3].Age = tire4Age;
    }
}