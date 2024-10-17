using CinemaWebApp.Data;
using CinemaWebApp.Models;
using CinemaWebApp.ViewModels.Movie;
using CinemaWebApp.ViewModels.Cinema;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace CinemaWebApp.Controllers;

public class CinemaController : Controller
{
    private readonly ApplicationDbContext _context;

    public CinemaController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    [HttpGet]
    public IActionResult Index()
    {
        var cinemas = _context.Cinemas.ToList();

        var cinemaIndexViewModels = cinemas.Select(c => new CinemaIndexViewModel()
        {
            Id = c.Id,
            Name = c.Name,
            Location = c.Location
        });
        
        return View(cinemaIndexViewModels);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CinemaCreateViewModel viewModel)
    {
        if (ModelState.IsValid)
        {
            var cinema = new Cinema()
            {
                Name = viewModel.Name,
                Location = viewModel.Location
            };
            
            _context.Cinemas.Add(cinema);
            _context.SaveChanges();
            
            return RedirectToAction("Index");
        }
        
        return View(viewModel);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        var cinema = _context.Cinemas
            .Include(c => c.CinemaMovies)
            .ThenInclude(cm => cm.Movie)
            .FirstOrDefault(c => c.Id == id);

        if (cinema is null)
        {
            return RedirectToAction("Index");
        }

        var cinemaDetailsViewModel = new CinemaDetailsViewModel()
        {
            Id = cinema.Id,
            Name = cinema.Name,
            Location = cinema.Location,
            Movies = cinema.CinemaMovies.Select(cm => new MovieProgramViewModel()
                {
                    Title = cm.Movie.Title,
                    Duration = cm.Movie.Duration,
                })
                .ToList()
        };

        return View(cinemaDetailsViewModel);
    }
}