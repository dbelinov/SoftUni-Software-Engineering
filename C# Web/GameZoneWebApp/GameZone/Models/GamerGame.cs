using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Models;

public class GamerGame
{
    public int GameId { get; set; }
    [ForeignKey(nameof(GameId))] 
    public virtual Game Game { get; set; } = null!;

    public string GamerId { get; set; } = string.Empty;
    [ForeignKey(nameof(GamerId))] 
    public virtual IdentityUser Gamer { get; set; } = null!;
}