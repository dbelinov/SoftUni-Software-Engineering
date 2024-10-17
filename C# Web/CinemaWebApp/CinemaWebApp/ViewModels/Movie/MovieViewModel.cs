using System.ComponentModel.DataAnnotations;
using System.Numerics;
using CinemaWebApp.Common.ErrorMessages;
using static CinemaWebApp.Common.ErrorMessages.MovieErrorMessages;
using static CinemaWebApp.Common.Constants.MovieConstants;

namespace CinemaWebApp.ViewModels.Movie;

public class MovieViewModel
{
    [Required(ErrorMessage = RequiredMovieTitle)]
    [StringLength(TitleMaxLength, ErrorMessage = MovieTitleTooLong)]
    public string Title { get; set; } = null!;
    
    [Required(ErrorMessage = ReguiredGenre)]
    public string Genre { get; set; } = null!;
    
    [Required(ErrorMessage = RequiredReleaseDate)]
    [DataType(DataType.Date)]
    public DateTime ReleaseDate { get; set; } = DateTime.Now;
    
    [Required(ErrorMessage = RequiredDirectorName)]
    [StringLength(DirectorNameMaxLength, ErrorMessage = DirectorNameTooLong)]
    public string Director { get; set; } = null!;
    
    [Required(ErrorMessage = RequiredDuration)]
    [Range(DurationMinValue, DurationMaxValue, ErrorMessage = DurationNotValid)]
    public int Duration { get; set; }
    public string Description { get; set; } = null!;

    public string ImageUrl { get; set; } = null!;
}