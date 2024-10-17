using CinemaWebApp.Data;
using CinemaWebApp.Models;
using CinemaWebApp.ViewModels.Watchlist;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace CinemaWebApp.Controllers;

public class WatchlistController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public WatchlistController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    public async Task<IActionResult> Index()
    {
        var userId = _userManager.GetUserId(User);

        var watchListMovies = await _context.UsersMovies
            .Where(um => um.UserId == userId)
            .Include(um => um.Movie)
            .Select(um => new WatchlistViewModel()
            {
                MovieId = um.MovieId,
                Title = um.Movie.Title,
                Genre = um.Movie.Genre,
                ReleaseDate = um.Movie.ReleaseDate.ToString("MMMM yyyy"),
                ImageUrl = um.Movie.ImageUrl,
            })
            .ToListAsync();
        
        return View(watchListMovies);
    }

    [HttpPost]
    public async Task<IActionResult> AddToWatchlist(int movieId)
    {
        var userId = _userManager.GetUserId(User);

        var userMovie = await _context.UsersMovies
            .FirstOrDefaultAsync(um => um.MovieId == movieId && um.UserId == userId);

        if (userMovie is null)
        {
            userMovie = new UserMovie()
            {
                UserId = userId,
                MovieId = movieId,
            };
            
            _context.UsersMovies.Add(userMovie);
            await _context.SaveChangesAsync();
        }
        
        return RedirectToAction("Index", "Movie");
    }

    [HttpPost]
    public async Task<IActionResult> RemoveFromWatchlist(int movieId)
    {
        var userId = _userManager.GetUserId(User);
        
        var userMovie = await _context.UsersMovies
            .FirstOrDefaultAsync(um => um.MovieId == movieId && um.UserId == userId);

        if (userMovie is not null)
        {
            _context.UsersMovies.Remove(userMovie);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }
}