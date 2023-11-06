namespace FootballTeamGenerator;

public class StartUp
{
    public static void Main()
    {
        List<Team> teams = new List<Team>();
        
        string input;
        while ((input = Console.ReadLine()) != "END")
        {
            string[] tokens = input.Split(";");
            try
            {
                switch (tokens[0])
                {
                    case "Team":
                        Team team = new Team(tokens[1]);
                        teams.Add(team);
                        break;
                    case "Add":
                        string teamName = tokens[1];
                        string playerName = tokens[2];
                        int endurance = int.Parse(tokens[3]);
                        int sprint = int.Parse(tokens[4]);
                        int dribble = int.Parse(tokens[5]);
                        int passing = int.Parse(tokens[6]);
                        int shooting = int.Parse(tokens[7]);

                        Team foundTeam = teams.FirstOrDefault(t => t.Name == teamName);
                        if (foundTeam == null)
                        {
                            throw new ArgumentException(string.Format(ExceptionMessages.MissingTeam, teamName));
                        }

                        Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        foundTeam.AddPlayer(player);
                        break;
                    case "Remove":
                        string nameOfTeam = tokens[1];
                        string nameOfPlayer = tokens[2];

                        Team neededTeam = teams.FirstOrDefault(t => t.Name == nameOfTeam);
                        if (neededTeam == null)
                        {
                            throw new ArgumentException(string.Format(ExceptionMessages.MissingTeam, nameOfTeam));
                        }
                        neededTeam.RemovePlayer(nameOfPlayer);
                        break;
                    case "Rating":
                        string nameOfTeamToRate = tokens[1];
                        Team ratedTeam = teams.FirstOrDefault(t => t.Name == nameOfTeamToRate);

                        if (ratedTeam == null)
                        {
                            throw new ArgumentException(string.Format(ExceptionMessages.MissingTeam, nameOfTeamToRate));
                        }

                        Console.WriteLine($"{nameOfTeamToRate} - {ratedTeam.Rating:f0}");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

