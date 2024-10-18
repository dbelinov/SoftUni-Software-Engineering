using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants.GenreConstants;

namespace GameZone.Models;

public class Genre
{
    [Key]
    public int Id { get; set; }

    [Required] 
    [MaxLength(NameMaxLength)] 
    public string Name { get; set; } = null!;

    public ICollection<Game> Games { get; set; } = new List<Game>();
}