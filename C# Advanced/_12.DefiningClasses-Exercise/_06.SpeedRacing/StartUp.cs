namespace DefiningClasses;

/*
2
AudiA4 23 0,3
BMW-M2 45 0,42
Drive BMW-M2 56
Drive AudiA4 5
Drive AudiA4 13
End

3
AudiA4 18 0,34
BMW-M2 33 0,41
Ferrari-488Spider 50 0,47
Drive Ferrari-488Spider 97
Drive Ferrari-488Spider 35
Drive AudiA4 85
Drive AudiA4 50
End   
*/

public class StartUp
{
    public static void Main()
    {
        Dictionary<string, Car> cars = new Dictionary<string, Car>();
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] tokens = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = tokens[0];
            double fuelAmount = double.Parse(tokens[1]);
            double fuelConsumptionPerKilometer = double.Parse(tokens[2]);

            Car car = new Car(model, fuelAmount, fuelConsumptionPerKilometer);

            if (!cars.ContainsKey(model))
            {
                cars.Add(model, car);
            }
        }

        string input;
        while ((input = Console.ReadLine()) != "End")
        {
            string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string model = tokens[1];
            double amountOfKm = double.Parse(tokens[2]);
            
            cars[model].Drive(amountOfKm);
        }

        foreach (Car car in cars.Values)
        {
            Console.WriteLine(car);
        }
    }
}