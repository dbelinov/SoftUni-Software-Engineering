using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Common.ValidationConstants.GameConstants;
using Microsoft.AspNetCore.Identity;

namespace GameZone.Models;

public class Game
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(TitleMaxLength)]
    public string Title { get; set; } = null!;

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string Description { get; set; } = null!;
    
    public string? ImageUrl { get; set; }
    
    [Required]
    public string PublisherId { get; set; }
    [ForeignKey(nameof(PublisherId))] 
    public IdentityUser Publisher { get; set; } = null!;
    
    [Required]
    public DateTime ReleasedOn { get; set; }
    
    [Required]
    public int GenreId { get; set; }
    [ForeignKey(nameof(GenreId))]
    public Genre Genre { get; set; } = null!;
    
    public ICollection<GamerGame> GamersGames { get; set; } = new List<GamerGame>();
}