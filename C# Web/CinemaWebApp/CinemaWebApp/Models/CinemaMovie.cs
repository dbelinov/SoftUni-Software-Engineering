using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CinemaWebApp.Models;

[PrimaryKey(nameof(CinemaId), nameof(MovieId))]
public class CinemaMovie
{
    public int CinemaId { get; set; }
    [ForeignKey(nameof(CinemaId))]
    public Cinema Cinema { get; set; } = null!;
    public int MovieId { get; set; }
    [ForeignKey(nameof(MovieId))]
    public Movie Movie { get; set; } = null!;
}