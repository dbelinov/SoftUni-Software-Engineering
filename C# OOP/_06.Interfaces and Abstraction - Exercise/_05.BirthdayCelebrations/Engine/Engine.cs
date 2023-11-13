using System.Threading.Channels;
using BirthdayCelebrations.Engine.Interfaces;
using BirthdayCelebrations.IO.Interfaces;
using BirthdayCelebrations.Models;
using BirthdayCelebrations.Models.Interfaces;

namespace BirthdayCelebrations.Engine;

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
        List<string> birthdates = new List<string>();

        string input;
        while ((input = reader.ReadLine()) != "End")
        {
            string[] tokens = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            switch (tokens[0])
            {
                case "Citizen":
                    string birthdate = tokens[4];
                    ICitizen citizen = new Citizen(tokens[1], int.Parse(tokens[2]), tokens[3], birthdate);
                    birthdates.Add(birthdate);
                    break;
                case "Robot":
                    IRobot robot = new Robot(tokens[1], tokens[2]);
                    break;
                case "Pet":
                    string petBirthdate = tokens[2];
                    IPet pet = new Pet(tokens[1], petBirthdate);
                    birthdates.Add(petBirthdate);
                    break;
            }
        }

        string year = reader.ReadLine();
        foreach (string birthdate in birthdates)
        {
            if (birthdate.EndsWith(year))
            {
                writer.WriteLine(birthdate);
            }
        }
    }
}