using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

[Table("Positions")]
public class Position
{
    [Key]
    public int PositionId { get; set; }
    
    [MaxLength(ValidationConstants.PositionNameLength)]
    public string Name { get; set; }

    public virtual List<Player> Players { get; set; } = new List<Player>();
}