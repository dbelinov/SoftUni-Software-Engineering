using System.Runtime.CompilerServices;
using Cars.Models.Interfaces;

namespace Cars.Models;

public class Tesla : ICar, IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        Model = model;
        Color = color;
        Battery = battery;
    }

    public string Model { get; private set; }
    public string Color { get; private set; }
    public int Battery { get; private set; }

    public string Start() => $"Engine start{Environment.NewLine}";

    public string Stop() => $"Breaaak!{Environment.NewLine}";

    public override string ToString()
        => $"{Color} {GetType().Name} {Model} with {Battery} Batteries{Environment.NewLine}{Start()}{Stop()}".Trim();
}