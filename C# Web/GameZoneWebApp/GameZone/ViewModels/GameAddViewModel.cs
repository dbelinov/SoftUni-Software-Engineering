using static GameZone.Common.ValidationConstants.GameConstants;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using GameZone.ViewModels;

namespace GameZone.ViewModels
{
    public class GameAddViewModel
    {
        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = string.Empty;

        public string? ImageUrl { get; set; } = string.Empty;

        [Required]
        [RegexStringValidator(@"^\d{4}-\d{2}-\d{2}$")]
        public string ReleasedOn { get; set; } = string.Empty;

        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        public virtual IEnumerable<GenreViewModel>? Genres { get; set; }
    }
}