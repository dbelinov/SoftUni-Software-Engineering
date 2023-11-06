namespace FootballTeamGenerator;

public class ExceptionMessages
{
    public const string EmptyName = "A name should not be empty.";
    public const string StatOutOfRange = "{0} should be between 0 and 100."; //0 - Stat Name
    public const string MissingPlayer = "Player {0} is not in {1} team."; //0 - Player Name; 1 - Team Name
    public const string MissingTeam = "Team {0} does not exist."; //0 - Team Name
}