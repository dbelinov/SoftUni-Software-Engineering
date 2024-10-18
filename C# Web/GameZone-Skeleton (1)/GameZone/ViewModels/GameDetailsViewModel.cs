namespace GameZone.ViewModels;

public class GameDetailsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string? ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Genre { get; set; } = string.Empty;
    public string ReleasedOn { get; set; } = string.Empty;
    public string Publisher { get; set; } = string.Empty;
}