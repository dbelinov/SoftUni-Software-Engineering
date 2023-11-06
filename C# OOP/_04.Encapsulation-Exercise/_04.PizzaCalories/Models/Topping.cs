namespace PizzaCalories;

public class Topping
{
    private Dictionary<string, double> toppings;

    private string name;
    private int weight;

    public Topping(string name, int weight)
    {
        toppings = new Dictionary<string, double>
        {
            { "meat", 1.2 }, { "veggies", 0.8 }, { "cheese", 1.1 }, {"sauce", 0.9}
        };
        
        Name = name;
        Weight = weight;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (!toppings.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidTopping, value));
            }

            name = value;
        }
    }
    public int Weight
    {
        get => weight;
        private set
        {
            if (value is < 1 or > 50)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.InvalidToppingWeight, name));
            }

            weight = value;
        }
    }

    public double Calories
    {
        get
        {
            double toppingModifier = toppings[Name.ToLower()];
            return 2 * Weight * toppingModifier;
        }
    }
}