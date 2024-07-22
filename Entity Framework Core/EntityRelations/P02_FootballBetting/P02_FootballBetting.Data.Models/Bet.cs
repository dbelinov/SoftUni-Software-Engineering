using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

[Table("Bets")]
public class Bet
{
    [Key]
    public int BetId { get; set; }
    
    public decimal Amount { get; set; }
    
    [MaxLength(ValidationConstants.BetPredictionLength)]
    public string Prediction { get; set; }
    
    public DateTime DateTime { get; set; }
    public int UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; }
    public int GameId { get; set; }
    [ForeignKey(nameof(GameId))]
    public virtual Game Game { get; set; }
}