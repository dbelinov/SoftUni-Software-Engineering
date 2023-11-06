namespace PizzaCalories;

public class StartUp
{
    public static void Main()
    {
        try
        {
            //missing name should throw custom exception - not using RemoveEmptyEntries
            string[] pizzaTokens = Console.ReadLine().Split();
            string[] doughTokens = Console.ReadLine().Split();

            string pizzaName = pizzaTokens[1];

            Dough dough = new(doughTokens[1], doughTokens[2], int.Parse(doughTokens[3]));

            Pizza pizza = new(pizzaName)
            {
                Dough = dough
            };

            while (true)
            {
                string toppingsInput = Console.ReadLine();

                if (toppingsInput == "END")
                {
                    break;
                }

                string[] toppingsTokens = toppingsInput.Split();

                Topping topping = new(toppingsTokens[1], int.Parse(toppingsTokens[2]));

                pizza.AddTopping(topping);
            }

            Console.WriteLine(pizza);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}