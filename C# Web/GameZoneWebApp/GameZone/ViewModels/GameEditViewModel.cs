using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants.GameConstants;
using static GameZone.Common.ErrorMessages.GameErrorMessages;

namespace GameZone.ViewModels;

public class GameEditViewModel
{
    [Required(ErrorMessage = TitleRequired)]
    [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = TitleLength)]
    public string Title { get; set; } = string.Empty;
    
    public string? ImageUrl { get; set; }
    
    [Required(ErrorMessage = DescriptionRequired)]
    [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = DescriptionLength)]
    public string Description { get; set; } = string.Empty;
    
    [Required(ErrorMessage = DescriptionRequired)]
    public string ReleasedOn { get; set; } = string.Empty;
    
    [Required(ErrorMessage = GenreRequired)]
    [Range(1, int.MaxValue)]
    public int GenreId { get; set; }

    [Required]
    public string PublisherId { get; set; } = string.Empty;

    public virtual IEnumerable<GenreViewModel> Genres { get; set; } = new List<GenreViewModel>();
}