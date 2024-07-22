using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

[Table("Users")]
public class User
{
    [Key]
    public int UserId { get; set; }
    
    [MaxLength(ValidationConstants.UserUsernameLength)]
    public string Username { get; set; }
    
    [MaxLength(ValidationConstants.UserPasswordLength)]
    public string Password { get; set; }
    
    [MaxLength(ValidationConstants.UserEmailLength)]
    public string Email { get; set; }
    
    public decimal Balance { get; set; }
    
    [MaxLength(ValidationConstants.UserNameLength)]
    public string Name { get; set; }

    public virtual List<Bet> Bets { get; set; } = new List<Bet>();
}