using System.Linq;
using System.Text;
using Handball.Core.Contracts;
using Handball.Models;
using Handball.Models.Contracts;
using Handball.Repositories;
using Handball.Utilities.Messages;

namespace Handball.Core;

public class Controller : IController
{
    private PlayerRepository players = new();
    private TeamRepository teams = new();

    public string NewTeam(string name)
    {
        ITeam team = new Team(name);

        if (teams.ExistsModel(name))
        {
            return string.Format(OutputMessages.TeamAlreadyExists, name, nameof(TeamRepository));
        }
        
        teams.AddModel(team);
        return string.Format(OutputMessages.TeamSuccessfullyAdded, name, nameof(TeamRepository));
    }

    public string NewPlayer(string typeName, string name)
    {
        IPlayer player;
        if (typeName == "CenterBack")
        {
            player = new CenterBack(name);
        }
        else if (typeName == "ForwardWing")
        {
            player = new ForwardWing(name);
        }
        else if (typeName == "Goalkeeper")
        {
            player = new Goalkeeper(name);
        }
        else
        {
            return string.Format(OutputMessages.InvalidTypeOfPosition, typeName);
        }

        if (players.ExistsModel(name))
        {
            return string.Format(OutputMessages.PlayerIsAlreadyAdded, name, nameof(PlayerRepository),
                players.GetModel(name).GetType().Name);
        }
        
        players.AddModel(player);
        return string.Format(OutputMessages.PlayerAddedSuccessfully, name);
    }

    public string NewContract(string playerName, string teamName)
    {
        if (!players.ExistsModel(playerName))
        {
            return string.Format(OutputMessages.PlayerNotExisting, playerName, nameof(PlayerRepository));
        }

        if (!teams.ExistsModel(teamName))
        {
            return string.Format(OutputMessages.TeamNotExisting, teamName, nameof(TeamRepository));
        }

        IPlayer player = players.GetModel(playerName);
        ITeam team = teams.GetModel(teamName);
        if (player.Team != null)
        {
            return string.Format(OutputMessages.PlayerAlreadySignedContract, playerName, player.Team);
        }

        player.JoinTeam(teamName);
        team.SignContract(player);

        return string.Format(OutputMessages.SignContract, playerName, teamName);
    }

    public string NewGame(string firstTeamName, string secondTeamName)
    {
        ITeam firstTeam = teams.GetModel(firstTeamName);
        ITeam secondTeam = teams.GetModel(secondTeamName);

        if (firstTeam.OverallRating > secondTeam.OverallRating)
        {
            firstTeam.Win();
            secondTeam.Lose();
            return string.Format(OutputMessages.GameHasWinner, firstTeamName, secondTeamName);
        }

        if (secondTeam.OverallRating > firstTeam.OverallRating)
        {
            secondTeam.Win();
            firstTeam.Lose();
            return string.Format(OutputMessages.GameHasWinner, secondTeamName, firstTeamName);
        }

        firstTeam.Draw();
        secondTeam.Draw();
        return string.Format(OutputMessages.GameIsDraw, firstTeamName, secondTeamName);
    }

    public string PlayerStatistics(string teamName)
    {
        StringBuilder sb = new StringBuilder();
        
        ITeam team = teams.GetModel(teamName);

        sb.AppendLine($"***{teamName}***");
        foreach (IPlayer player in team.Players.OrderByDescending(p => p.Rating).ThenBy(p => p.Name))
        {
            sb.AppendLine(player.ToString());
        }

        return sb.ToString().Trim();
    }

    public string LeagueStandings()
    {
        StringBuilder sb = new StringBuilder();

        sb.AppendLine("***League Standings***");
        foreach (ITeam team in teams.Models
                     .OrderByDescending(t => t.PointsEarned)
                     .ThenByDescending(t => t.OverallRating)
                     .ThenBy(t => t.Name))
        {
            sb.AppendLine(team.ToString());
        }

        return sb.ToString().Trim();
    }
}