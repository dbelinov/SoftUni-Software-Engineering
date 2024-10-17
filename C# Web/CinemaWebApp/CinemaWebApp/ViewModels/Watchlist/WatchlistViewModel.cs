namespace CinemaWebApp.ViewModels.Watchlist;

public class WatchlistViewModel
{
    public int MovieId { get; set; }
    public string Title { get; set; } = null!;
    public string Genre { get; set; } = null!;
    public string ReleaseDate { get; set; } = null!;
    public string ImageUrl { get; set; } = null!;
}