using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Footballers.Data.Models.Enums;

namespace Footballers.Data.Models;

public class Footballer
{
    public Footballer()
    {
        TeamsFootballers = new List<TeamFootballer>();
    }
    
    [Key]
    public int Id { get; set; }
    
    [Required]
    [MaxLength(40)]
    public string Name { get; set; }
    
    [Required]
    public DateTime ContractStartDate { get; set; }
    
    [Required]
    public DateTime ContractEndDate { get; set; }
    
    [Required]
    public PositionType PositionType { get; set; }
    
    [Required]
    public BestSkillType BestSkillType { get; set; }
    
    [Required]
    public int CoachId { get; set; }
    [ForeignKey(nameof(CoachId))]
    public Coach Coach { get; set; }
    
    public ICollection<TeamFootballer> TeamsFootballers { get; set; }
}