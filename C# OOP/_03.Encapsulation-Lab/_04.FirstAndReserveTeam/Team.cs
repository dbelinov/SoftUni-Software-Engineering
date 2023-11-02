using System.Text;

namespace PersonsInfo;

public class Team
{
    public Team(string name)
    {
        Name = name;
        FirstTeam = new List<Person>();
        ReserveTeam = new List<Person>();
    }

    public string Name { get; private set; }
    public List<Person> FirstTeam { get; private set; }
    public List<Person> ReserveTeam { get; private set; }

    public void AddPlayer(Person person)
    {
        if (person.Age < 40)
        {
            FirstTeam.Add(person);
        }
        else
        {
            ReserveTeam.Add(person);
        }
    }

    public override string ToString()
    {
        return $"First team has {FirstTeam.Count} players.{Environment.NewLine}Reserve team has {ReserveTeam.Count} players.";
    }
}