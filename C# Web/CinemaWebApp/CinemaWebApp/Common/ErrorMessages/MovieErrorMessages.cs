namespace CinemaWebApp.Common.ErrorMessages;

public static class MovieErrorMessages
{
    public const string RequiredMovieTitle = "Movie title is required.";
    public const string ReguiredGenre = "Genre is required.";
    public const string RequiredReleaseDate = "Release date is required.";
    public const string RequiredDirectorName = "Director name is required.";
    public const string RequiredDuration = "Duration is required.";
    public const string MovieTitleTooLong = "Movie title is too long.";
    public const string DirectorNameTooLong = "Director name is too long.";
    public const string DurationNotValid = "Duration must be between 1 and 500 minutes.";
}