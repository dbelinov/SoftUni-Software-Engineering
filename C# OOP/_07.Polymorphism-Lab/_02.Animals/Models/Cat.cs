namespace Animals.Models;

public class Cat : Animal
{
    private const string Sound = "MEEOW";
    public Cat(string name, string favouriteFood) : base(name, favouriteFood)
    {
    }

    public override string ExplainSelf() => base.ExplainSelf() + Environment.NewLine + Sound;
}