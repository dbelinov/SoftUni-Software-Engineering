using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models;

public class Team : ITeam
{
    private string name;
    private List<IPlayer> players;

    public Team(string name)
    {
        Name = name;
        PointsEarned = 0;

        players = new List<IPlayer>();
    }
    
    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.TeamNameNull);
            }

            name = value;
        }
    }
    public int PointsEarned { get; private set; }

    public double OverallRating
    {
        get
        {
            if (Players.Count > 0)
            {
                return Math.Round(Players.Average(p => p.Rating), 2);
            }

            return 0;
        }
    }

    public IReadOnlyCollection<IPlayer> Players => players.AsReadOnly();

    public void SignContract(IPlayer player) => players.Add(player);

    public void Win()
    {
        PointsEarned += 3;
        foreach (IPlayer player in players)
        {
            player.IncreaseRating();
        }
    }

    public void Lose()
    {
        foreach (IPlayer player in players)
        {
            player.DecreaseRating();
        }
    }

    public void Draw()
    {
        PointsEarned += 1;
        IPlayer goalkeeper = players.FirstOrDefault(p => p is Goalkeeper);

        if (goalkeeper is not null)
        {
            goalkeeper.IncreaseRating();
        }
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        string playersToString = "none";
        if (players.Count > 0)
        {
            playersToString = string.Join(", ", players.Select(p => p.Name));
        }
        
        sb.AppendLine($"Team: {Name} Points: {PointsEarned}");
        sb.AppendLine($"--Overall rating: {OverallRating}");
        sb.AppendLine($"--Players: {playersToString}");

        return sb.ToString().Trim();
    }
}