namespace FootballTeamGenerator;

public class Team
{
    private List<Player> players;
    private string name;

    public Team(string name)
    {
        Name = name;
        players = new List<Player>();
    }

    public string Name
    {
        get => name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.EmptyName);
            }

            name = value;
        }
    }
    
    public double Rating
    {
        get
        {
            if (players.Any())
            {
                return players.Average(x => x.Stats);
            }

            return 0;
        }
    }

    public void AddPlayer(Player player) => players.Add(player);

    public void RemovePlayer(string playerName)
    {
        Player foundPlayer = players.FirstOrDefault(p => p.Name == playerName);
        if (foundPlayer == null)
        {
            throw new ArgumentException(string.Format(ExceptionMessages.MissingPlayer, playerName, Name));
        }

        players.Remove(foundPlayer);
    }
}