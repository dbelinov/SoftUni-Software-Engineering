using CinemaWebApp.Data;
using Microsoft.AspNetCore.Mvc;
using CinemaWebApp.Models;
using CinemaWebApp.ViewModels.Movie;
using CinemaWebApp.ViewModels.Cinema;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CinemaWebApp.Controllers;

public class MovieController : Controller
{
    private readonly ApplicationDbContext _context;
    
    public MovieController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        var movies = _context.Movies.ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View(new MovieViewModel());
    }

    [HttpPost]
    public IActionResult Create(MovieViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            Movie movie = new Movie()
            {
                Title = viewModel.Title,
                Genre = viewModel.Genre,
                ReleaseDate = viewModel.ReleaseDate,
                Director = viewModel.Director,
                Duration = viewModel.Duration,
                Description = viewModel.Description,
                ImageUrl = viewModel.ImageUrl,
            };
        
            _context.Movies.Add(movie);
            _context.SaveChanges();
        
            return RedirectToAction("Index");
        }
        
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        Movie movie = _context.Movies.FirstOrDefault(m => m.Id == id);

        if (movie == null)
        {
            return NotFound();
        }
        
        return View(movie);
    }

    [HttpGet]
    public IActionResult AddToProgram(int movieId)
    {
        var movie = _context.Movies.FirstOrDefault(m => m.Id == movieId);

        if (movie is null)
        {
            return RedirectToAction("Index");
        }

        var cinemas = _context.Cinemas.ToList();

        var viewModel = new AddMovieToCinemaProgramViewModel()
        {
            MovieId = movie.Id,
            MovieTitle = movie.Title,
            Cinemas = cinemas.Select(c => new CinemaCheckboxViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    IsSelected = false
                })
                .ToList()
        };
        
        return View(viewModel);
    }

    [HttpPost]
    public IActionResult AddToProgram(AddMovieToCinemaProgramViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            return View(viewModel);
        }

        var existingAssignments = _context.CinemasMovies
            .Where(cm => cm.MovieId == viewModel.MovieId)
            .ToList();
        _context.RemoveRange(existingAssignments);

        foreach (var cinema in viewModel.Cinemas)
        {
            if (cinema.IsSelected)
            {
                var cinemaMovie = new CinemaMovie()
                {
                    MovieId = viewModel.MovieId,
                    CinemaId = cinema.Id,
                };
                
                _context.CinemasMovies.Add(cinemaMovie);
            }
        }
        
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}