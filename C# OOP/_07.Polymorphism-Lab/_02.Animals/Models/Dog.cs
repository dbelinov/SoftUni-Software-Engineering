namespace Animals.Models;

public class Dog : Animal
{
    private const string Sound = "DJAAF";
    public Dog(string name, string favouriteFood) : base(name, favouriteFood)
    {
    }

    public override string ExplainSelf() => base.ExplainSelf() + Environment.NewLine + Sound;
}