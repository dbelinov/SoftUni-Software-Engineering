using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

[Table("Players")]
public class Player
{
    [Key]
    public int PlayerId { get; set; }
    
    [MaxLength(ValidationConstants.PlayerNameLength)]
    public string Name { get; set; }
    
    public int SquadNumber { get; set; }
    public int TownId { get; set; }
    [ForeignKey(nameof(TownId))]
    public virtual Town Town { get; set; }
    public int PositionId { get; set; }
    [ForeignKey(nameof(PositionId))]
    public virtual Position Position { get; set; }
    
    public bool IsInjured { get; set; }
    public int TeamId { get; set; }
    [ForeignKey(nameof(TeamId))]
    public virtual Team Team { get; set; }

    public virtual List<PlayerStatistic> PlayersStatistics { get; set; } = new List<PlayerStatistic>();
}