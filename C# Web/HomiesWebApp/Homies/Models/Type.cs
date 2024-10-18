using System.ComponentModel.DataAnnotations;
using static Homies.Common.ErrorMessages.TypeErrorMessages;
using static Homies.Common.ValidationConstants.TypeValidationConstants;

namespace Homies.Models;

public class Type
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = TypeNameRequired)]
    [StringLength(NameMaxLength, MinimumLength = NameMinLength, ErrorMessage = TypeNameLength)]
    public string Name { get; set; } = string.Empty;

    public ICollection<Event> Events { get; set; } = new List<Event>();
}