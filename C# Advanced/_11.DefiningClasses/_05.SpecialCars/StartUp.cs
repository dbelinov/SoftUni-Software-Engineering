using System.Threading.Channels;

/*
2 2,6 3 1,6 2 3,6 3 1,6
1 3,3 2 1,6 5 2,4 1 3,2
No more tires
331 2,2
145 2,0
Engines done
Audi A5 2017 200 12 0 0
BMW X5 2007 175 18 1 1
Show special
*/

namespace CarManufacturer
{
    public class StartUp
    {
        public static void Main()
        {
            List<List<Tire>> tires = new List<List<Tire>>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();
            
            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                List<Tire> currentSet = new List<Tire>();
                for (int i = 0; i < tokens.Length; i += 2)
                {
                    int year = int.Parse(tokens[i]);
                    double pressure = double.Parse(tokens[i + 1]);
                    currentSet.Add(new Tire(year, pressure));
                }
                tires.Add(currentSet);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                int horsePower = int.Parse(tokens[0]);
                double cubicCapacity = double.Parse(tokens[1]);

                Engine engine = new Engine(horsePower, cubicCapacity);
                engines.Add(engine);
            }

            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string make = tokens[0];
                string model = tokens[1];
                int year = int.Parse(tokens[2]);
                double fuelQuantity = double.Parse(tokens[3]);
                double fuelConsumption = double.Parse(tokens[4]);
                int engineIndex = int.Parse(tokens[5]);
                int tiresIndex = int.Parse(tokens[6]);
                
                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex].ToArray());
                cars.Add(car);
            }

            List<Car> specialCars = cars.FindAll(c => c.Year >= 2017
                                                      && c.Engine.HorsePower > 330
                                                      && c.Tires.Select(t => t.Pressure).Sum() >= 9
                                                      && c.Tires.Select(t => t.Pressure).Sum() <= 10);
            
            foreach (Car car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car);
            }
        }
    }
}

