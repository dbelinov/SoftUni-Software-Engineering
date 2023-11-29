namespace Handball.Models;

public class Goalkeeper : Player
{
    private const double initialRating = 2.5;

    public Goalkeeper(string name) : base(name, initialRating)
    {
    }

    public override void IncreaseRating() => Rating += 0.75;

    public override void DecreaseRating() => Rating -= 1.25;
}