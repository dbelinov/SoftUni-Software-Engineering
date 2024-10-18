using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Homies.Models;

[PrimaryKey(nameof(HelperId), nameof(EventId))]
public class EventParticipant
{
    [Required]
    public string HelperId { get; set; } = string.Empty;
    [ForeignKey(nameof(HelperId))]
    public IdentityUser Helper { get; set; }
    
    [Required]
    public int EventId { get; set; }
    [ForeignKey(nameof(EventId))]
    public Event Event { get; set; }
}