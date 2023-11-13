using System.Security.Cryptography.X509Certificates;
using FoodShortage.IO.Interfaces;
using FoodShortage.Models;
using FoodShortage.Models.Interfaces;
using FoodShortage.Engine.Interfaces;

namespace FoodShortage.Engine;

public class Engine : IEngine
{
    private IReader reader;
    private IWriter writer;
    public Engine(IReader reader, IWriter writer)
    {
        this.reader = reader;
        this.writer = writer;
    }
    public void Run()
    {
        List<IBuyer> buyers = new List<IBuyer>();
        
        int people = int.Parse(reader.ReadLine());
        for (int i = 0; i < people; i++)
        {
            string[] tokens = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IBuyer buyer;
            if (tokens.Length == 4)
            {
                buyer = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
            }
            else
            {
                buyer = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);
            }
            
            buyers.Add(buyer);
        }

        string name;
        while ((name = reader.ReadLine()) != "End")
        {
            buyers.FirstOrDefault(b => b.Name == name)?.BuyFood();
        }

        Console.WriteLine(buyers.Sum(b => b.Food));
    }
}