using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

[Table("Teams")]
public class Team
{
    [Key]
    public int TeamId { get; set; }
    
    [MaxLength(ValidationConstants.TeamNameLength)]
    public string Name { get; set; }
    
    [MaxLength(ValidationConstants.TeamUrlLogoLength)]
    public string LogoUrl { get; set; }
    
    [MaxLength(ValidationConstants.TeamInitialsLength)]
    public string Initials { get; set; }
    
    public decimal Budget { get; set; }
    
    public int PrimaryKitColorId { get; set; }
    [ForeignKey(nameof(PrimaryKitColorId))]
    public virtual Color PrimaryKitColor { get; set; }
    
    public int SecondaryKitColorId { get; set; }
    [ForeignKey(nameof(SecondaryKitColorId))]
    public virtual Color SecondaryKitColor { get; set; }
    
    public int TownId { get; set; }
    [ForeignKey(nameof(TownId))]
    public virtual Town Town { get; set; }

    public virtual List<Game> HomeGames { get; set; } = new List<Game>();
    public virtual List<Game> AwayGames { get; set; } = new List<Game>();
    public virtual List<Player> Players { get; set; } = new List<Player>();
}