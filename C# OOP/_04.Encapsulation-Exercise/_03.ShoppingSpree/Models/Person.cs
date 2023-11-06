namespace ShoppingSpree;

public class Person
{
    private string name;
    private decimal money;
    
    public Person(string name, decimal money)
    {
        Name = name;
        Money = money;
        Products = new List<Product>();
    }
    
    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            name = value;
        }
    }

    public decimal Money
    {
        get => money;
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }

            money = value;
        }
    }

    public List<Product> Products { get; private set; }

    public string Add(Product product)
    {
        if (Money < product.Cost)
        {
            return $"{Name} can't afford {product.Name}";
        }

        Products.Add(product);

        Money -= product.Cost;

        return $"{Name} bought {product.Name}";
    }
    
    public override string ToString()
    {
        string productsString = Products.Any()
            ? string.Join(", ", Products.Select(p => p.Name))
            : "Nothing bought";

        return $"{Name} - {productsString}";
    }
}