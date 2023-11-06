namespace PizzaCalories;

public class Dough
{
    private Dictionary<string, double> flourTypes;
    private Dictionary<string, double> bakingTechniques;

    private int weight;
    private string flourType;
    private string bakingTechnique;

    public Dough(string flourType, string bakingTechnique, int weight)
    {
        flourTypes = new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };
        bakingTechniques = new Dictionary<string, double> { {"crispy", 0.9}, {"chewy", 1.1}, {"homemade", 1.0} };
        
        FlourType = flourType;
        BakingTechnique = bakingTechnique;
        Weight = weight;
    }

    public string FlourType
    {
        get => flourType;
        private set
        {
            if (!flourTypes.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException(ExceptionMessages.InvalidDough);
            }

            flourType = value;
        }
    }
    public string BakingTechnique
    {
        get => bakingTechnique;
        private set
        {
            if (!bakingTechniques.ContainsKey(value.ToLower()))
            {
                throw new ArgumentException(ExceptionMessages.InvalidDough);
            }

            bakingTechnique = value;
        }
    }
    public int Weight
    {
        get => weight;
        private set
        {
            if (value is < 0 or > 200)
            {
                throw new ArgumentException(ExceptionMessages.InvalidDoughWeight);
            }

            weight = value;
        }
    }


    public double Calories
    {
        get
        {
            double flourTypeModifier = flourTypes[FlourType.ToLower()];
            double bakingTechniqueModifier = bakingTechniques[BakingTechnique.ToLower()];

            return 2 * Weight * flourTypeModifier * bakingTechniqueModifier;
        }
    }
}