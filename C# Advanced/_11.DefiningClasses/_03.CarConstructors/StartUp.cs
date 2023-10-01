namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());
            
            Car car = new Car();
            Car car2 = new Car(make, model, year);
            Car car3 = new Car(make, model, year, fuelQuantity, fuelConsumption);
        }
    }
}