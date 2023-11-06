using System.Xml.Schema;

namespace PizzaCalories;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    
    public Pizza(string name)
    {
        Name = name;
        
        toppings = new List<Topping>();
    }

    public string Name
    {
        get => name;
        private set
        {
            if (value.Length is < 1 or > 15)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPizzaName);
            }

            name = value;
        }
    }

    public Dough Dough { get; set; }

    public double Calories
    {
        get
        {
            return toppings.Sum(t => t.Calories) + Dough.Calories;
        }
    }

    public void AddTopping(Topping topping)
    {
        if (toppings.Count == 10)
        {
            throw new ArgumentException(ExceptionMessages.TooManyToppings);
        }
        
        toppings.Add(topping);
    }

    public override string ToString()
    {
        return $"{Name} - {Calories:f2} Calories.";
    }
}