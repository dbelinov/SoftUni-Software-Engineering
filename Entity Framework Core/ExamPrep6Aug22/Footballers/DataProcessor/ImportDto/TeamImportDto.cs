using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace Footballers.DataProcessor.ImportDto;

public class TeamImportDto
{
    [Required]
    [MinLength(3)]
    [MaxLength(40)]
    [RegularExpression(@"[a-zA-Z0-9 .-]+")]
    public string Name { get; set; }
    
    [Required]
    [MinLength(2)]
    [MaxLength(40)]
    public string Nationality { get; set; }
    
    [Required]
    [Range(1, int.MaxValue)]
    public int Trophies { get; set; }
    
    public int[] Footballers { get; set; }
}