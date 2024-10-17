using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Models;

[PrimaryKey(nameof(UserId), nameof(MovieId))]
public class UserMovie
{
    public string UserId { get; set; }
    [ForeignKey(nameof(UserId))]
    public IdentityUser User { get; set; }
    
    public int MovieId { get; set; }
    [ForeignKey(nameof(MovieId))]
    public Movie Movie { get; set; }
}