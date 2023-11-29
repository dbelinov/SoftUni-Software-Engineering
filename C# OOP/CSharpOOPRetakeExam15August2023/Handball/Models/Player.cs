using System;
using System.Text;
using Handball.Models.Contracts;
using Handball.Utilities.Messages;

namespace Handball.Models;

public abstract class Player : IPlayer
{
    private string name;
    private double rating;

    protected Player(string name, double rating)
    {
        Name = name;
        Rating = rating;
    }

    public string Name
    {
        get => name;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException(ExceptionMessages.PlayerNameNull);
            }

            name = value;
        }
    }

    public double Rating
    {
        get => rating;
        protected set
        {
            if (value >= 10)
            {
                rating = 10;
                return;
            }
            
            if (value <= 1)
            {
                rating = 1;
                return;
            }
            
            rating = value;
        }
    }

    public string Team { get; private set; }

    public void JoinTeam(string name) => Team = name;

    public abstract void IncreaseRating();

    public abstract void DecreaseRating();

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        
        sb.AppendLine($"{GetType().Name}: {Name}");
        sb.AppendLine($"--Rating: {Rating}");
        
        return sb.ToString().Trim();
    }
}