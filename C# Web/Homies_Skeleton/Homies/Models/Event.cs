using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Homies.Models;
using static Homies.Common.ErrorMessages.EventErrorMessages;
using static Homies.Common.ValidationConstants.EventValidationConstants;
using Type = Homies.Models.Type;

namespace Homies.Models;

public class Event
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = EventNameRequired)]
    [StringLength(EventNameMaxLength, MinimumLength = EventNameMinLength, ErrorMessage = EventNameLength)]
    public string Name { get; set; } = string.Empty;
    
    [Required(ErrorMessage = EventDescriptionRequired)]
    [StringLength(EventDescriptionMaxLength, MinimumLength = EventDescriptionMinLength, ErrorMessage = EventDescriptionLength)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    public string OrganiserId { get; set; } = string.Empty;
    [ForeignKey(nameof(OrganiserId))]
    public IdentityUser Organiser { get; set; }
    
    [Required(ErrorMessage = CreatedDateRequired)]
    public DateTime CreatedOn { get; set; }
    
    [Required(ErrorMessage = StartDateRequired)]
    public DateTime Start { get; set; }
    
    [Required(ErrorMessage = EndDateRequired)]
    public DateTime End { get; set; }
    
    [Required]
    public int TypeId { get; set; }
    [ForeignKey(nameof(TypeId))]
    public Type Type { get; set; }

    public ICollection<EventParticipant> EventParticipants { get; set; } = new List<EventParticipant>();
}