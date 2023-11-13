namespace Shapes.Models;

public class Circle : Shape
{
    private int radius;

    public Circle(int radius)
    {
        this.radius = radius;
    }

    public override double CalculatePerimeter() => 2 * Math.PI * radius;
    public override double CalculateArea() => Math.PI * radius * radius;
    public override string Draw() => base.Draw() + GetType().Name;
}