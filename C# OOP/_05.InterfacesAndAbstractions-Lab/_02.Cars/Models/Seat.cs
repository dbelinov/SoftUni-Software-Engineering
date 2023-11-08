using Cars.Models.Interfaces;

namespace Cars.Models;

public class Seat : ICar
{
    public Seat(string model, string color)
    {
        Model = model;
        Color = color;
    }

    public string Model { get; private set; }
    public string Color { get; private set; }

    public string Start() => $"Engine start{Environment.NewLine}";

    public string Stop() => $"Breaaak!{Environment.NewLine}";
    
    public override string ToString() => $"{Color} {GetType().Name} {Model}{Environment.NewLine}{Start()}{Stop()}".Trim();
}