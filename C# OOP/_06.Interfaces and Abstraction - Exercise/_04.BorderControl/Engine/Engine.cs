using System.Threading.Channels;
using BorderControl.Engine.Interfaces;
using BorderControl.IO.Interfaces;
using BorderControl.Models;
using BorderControl.Models.Interfaces;

namespace BorderControl.Engine;

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
        List<string> ids = new List<string>();
        
        string input;
        while ((input = reader.ReadLine()) != "End")
        {
            string[] tokens = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string id;
            
            if (tokens.Length == 3)
            {
                id = tokens[2];
                ICitizen citizen = new Citizen(tokens[0], int.Parse(tokens[1]), id);
            }
            else
            {
                id = tokens[1];
                IRobot robot = new Robot(tokens[0], id);
            }
            
            ids.Add(id);
        }

        string digitsToFind = reader.ReadLine();

        foreach (string id in ids)
        {
            if (id.EndsWith(digitsToFind))
            {
                writer.WriteLine(id);
            }
        }
    }
}