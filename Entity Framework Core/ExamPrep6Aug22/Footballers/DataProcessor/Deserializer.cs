using System.Globalization;
using System.Text;
using Footballers.Data.Models;
using Footballers.Data.Models.Enums;
using Footballers.DataProcessor.ImportDto;
using Footballers.Helper;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Newtonsoft.Json;

namespace Footballers.DataProcessor
{
    using Footballers.Data;
    using System.ComponentModel.DataAnnotations;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var importDtos = XmlSerializationHelper.Deserialize<CoachImportDto[]>(xmlString, "Coaches");

            List<Coach> coaches = new List<Coach>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var dto in importDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach()
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality
                };

                foreach (var fdto in dto.Footballers)
                {
                    if (!IsValid(fdto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    bool startDateValid = DateTime.TryParseExact(fdto.ContractStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime validStartDate);

                    bool endDateValid = DateTime.TryParseExact(fdto.ContractEndDate, "dd/MM/yyyy",CultureInfo.InvariantCulture,
                        DateTimeStyles.None, out DateTime validEndDate);

                    if (!startDateValid || !endDateValid || validStartDate > validEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        CoachId = coach.Id,
                        Name = fdto.Name,
                        ContractStartDate = validStartDate,
                        ContractEndDate = validEndDate,
                        BestSkillType = (BestSkillType)fdto.BestSkillType,
                        PositionType = (PositionType)fdto.PositionType
                    };
                    
                    coach.Footballers.Add(footballer);
                }
                
                coaches.Add(coach);
                sb.AppendLine(string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count));
            }
            
            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var importDtos = JsonConvert.DeserializeObject<TeamImportDto[]>(jsonString);

            List<Team> teams = new List<Team>();
            StringBuilder sb = new StringBuilder();
            
            foreach (var dto in importDtos)
            {
                if (!IsValid(dto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = new Team()
                {
                    Name = dto.Name,
                    Nationality = dto.Nationality,
                    Trophies = dto.Trophies
                };

                foreach (int id in dto.Footballers.Distinct())
                {
                    if (!context.Footballers.Any(f => f.Id == id))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer teamFootballer = new TeamFootballer()
                    {
                        FootballerId = id,
                        TeamId = team.Id
                    };
                    
                    team.TeamsFootballers.Add(teamFootballer);
                }
                
                teams.Add(team);
                sb.AppendLine(string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count));
            }
            
            context.Teams.AddRange(teams);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
