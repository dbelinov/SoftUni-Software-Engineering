using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

[Table("Towns")]
public class Town
{
    [Key]
    public int TownId { get; set; }
    
    [MaxLength(ValidationConstants.TownNameLength)]
    public string Name { get; set; }
    
    public int CountryId { get; set; }
    [ForeignKey(nameof(CountryId))]
    public virtual Country Country { get; set; }

    public virtual List<Team> Teams { get; set; } = new List<Team>();
    public virtual List<Player> Players { get; set; } = new List<Player>();
}