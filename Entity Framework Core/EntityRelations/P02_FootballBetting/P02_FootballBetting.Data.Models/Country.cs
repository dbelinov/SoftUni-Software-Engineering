using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime;
using P02_FootballBetting.Common;

namespace P02_FootballBetting.Data.Models;

[Table("Countries")]
public class Country
{
    [Key]
    public int CountryId { get; set; }
    
    [MaxLength(ValidationConstants.CountryNameLength)]
    public string Name { get; set; }

    public virtual List<Town> Towns { get; set; } = new List<Town>();
}