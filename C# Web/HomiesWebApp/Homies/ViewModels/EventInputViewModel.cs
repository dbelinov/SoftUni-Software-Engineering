using System.ComponentModel.DataAnnotations;
using static Homies.Common.ValidationConstants.EventValidationConstants;
using static Homies.Common.ErrorMessages.EventErrorMessages;
using Type = Homies.Models.Type;

namespace Homies.ViewModels;

public class EventInputViewModel
{
    [Required]
    public int Id { get; set; }
    
    [Required(ErrorMessage = EventNameRequired)]
    [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength, ErrorMessage = EventNameRequired)]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = EventDescriptionRequired)]
    [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = EventDescriptionRequired)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public string Start { get; set; } = string.Empty;
    
    [Required]
    public string End { get; set; } = string.Empty;
    
    [Required]
    public int TypeId { get; set; }

    [Required]
    public string OrganiserId { get; set; } = string.Empty;
    
    public ICollection<TypeViewModel> Types { get; set; } = new List<TypeViewModel>();
}