namespace ClassBoxData;

public class Box
{
    private const string Message = "{0} cannot be zero or negative.";

    private double length;
    private double width;
    private double height;
    
    public Box(double length, double width, double height)
    {
        Length = length;
        Width = width;
        Height = height;
    }

    public double Length
    {
        get => length;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(Message, nameof(Length)));
            }

            length = value;
        }
    }
    public double Width
    {
        get => width;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(Message, nameof(Width)));
            }

            width = value;
        }
    }
    public double Height
    {
        get => height;
        private set
        {
            if (value <= 0)
            {
                throw new ArgumentException(string.Format(Message, nameof(Height)));
            }

            height = value;
        }
    }

    public double LateralSurfaceArea()
    {
        return 2 * Length * Height + 2 * Width * Height;
    }
    
    public double SurfaceArea()
    {
        return 2 * Length * Width + LateralSurfaceArea();
    }

    public double Volume()
    {
        return Length * Width * Height;
    }
}