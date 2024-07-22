using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

[Table("Colors")]
public class Color
{
    [Key]
    public int ColorId { get; set; }
    
    [MaxLength(ValidationConstants.ColorNameLength)]
    public string Name { get; set; }

    public virtual List<Team> PrimaryKitTeams { get; set; } = new List<Team>();
    public virtual List<Team> SecondaryKitTeams { get; set; } = new List<Team>();
}