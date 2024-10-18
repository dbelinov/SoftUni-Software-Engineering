using System.Globalization;
using GameZone.Data;
using GameZone.Migrations;
using GameZone.Models;
using GameZone.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using static GameZone.Common.ValidationConstants.GameConstants;

namespace GameZone.Controllers;

[Authorize]
public class GameController : Controller
{
    private readonly GameZoneDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public GameController(GameZoneDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> All()
    {
        var games = await _context.Games
            .Select(g => new GameAllViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                ImageUrl = g.ImageUrl,
                ReleasedOn = g.ReleasedOn.ToString(ReleaseDateFormat),
                Publisher = g.Publisher.UserName,
                Genre = g.Genre.Name,
            })
            .ToListAsync();
        
        return View(games);
    }

    [HttpGet]
    public IActionResult Add()
    {
        var genres = _context.Genres
            .Select(g => new GenreViewModel()
            {
                Id = g.Id,
                Name = g.Name
            })
            .ToList();

        var model = new GameAddViewModel()
        {
            Genres = genres,
        };
        
        return View(model);
    }
    
    [HttpPost]
    public async Task<IActionResult> Add(GameAddViewModel model)
    {
        var currentUser = await _userManager.GetUserAsync(User);

        string releaseDateString = model.ReleasedOn;
        if (!DateTime.TryParseExact(releaseDateString, ReleaseDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate))
        {
            throw new InvalidOperationException("Invalid date format");
        }
        
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        Game game = new Game()
        {
            Title = model.Title,
            Description = model.Description,
            ImageUrl = model.ImageUrl,
            ReleasedOn = releaseDate,
            GenreId = model.GenreId,
            PublisherId = currentUser.Id,
        };
            
        await _context.Games.AddAsync(game);
        await _context.SaveChangesAsync();
            
        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> MyZone()
    {
        var user = await _userManager.GetUserAsync(User);

        var games = await _context.GamersGames
            .Where(gg => gg.GamerId == user.Id)
            .Include(gg => gg.Game)
            .Select(gg => new AddGameToMyZoneViewModel()
            {
                Title = gg.Game.Title,
                Genre = gg.Game.Genre.Name,
                Id = gg.Game.Id,
                ImageUrl = gg.Game.ImageUrl,
                Publisher = gg.Game.Publisher.UserName,
                ReleasedOn = gg.Game.ReleasedOn.ToString(ReleaseDateFormat),
            }) 
            .ToListAsync();
        
        return View(games);
    }
    
    public async Task<IActionResult> AddToMyZone(int id)
    {
        var user = await _userManager.GetUserAsync(User);

        var game = _context.Games
            .FirstOrDefault(g => g.Id == id);

        if (game is null)
        {
            return BadRequest();
        }
        
        if (_context.GamersGames.Any(gg => gg.GamerId == user.Id && gg.GameId == id))
        {
            return RedirectToAction("All");
        }
        
        var gamerGame = new GamerGame()
        {
            GamerId = user.Id,
            GameId = game.Id,
        };
            
        await _context.GamersGames.AddAsync(gamerGame);
        await _context.SaveChangesAsync();
 
        return RedirectToAction("MyZone");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var genres = await _context.Genres
            .Select(g => new GenreViewModel()
            {
                Id = g.Id,
                Name = g.Name,
            })
            .ToListAsync();

        var game = await _context.Games
            .Where(g => g.Id == id)
            .Select(g => new GameEditViewModel()
            {
                Title = g.Title,
                Description = g.Description,
                ReleasedOn = g.ReleasedOn.ToString(ReleaseDateFormat),
                ImageUrl = g.ImageUrl,
                GenreId = g.GenreId,
                Genres = genres,
                PublisherId = g.PublisherId,
            })
            .FirstOrDefaultAsync();

        if (game is null)
        {
            return BadRequest();
        }
        
        var user = await _userManager.GetUserAsync(User);
        if (user.Id != game.PublisherId)
        {
            return Unauthorized();
        }

        return View(game);
    }

    public async Task<IActionResult> Edit(int id, GameEditViewModel model)
    {
        var game = _context.Games
            .FirstOrDefault(g => g.Id == id);

        if (game is null)
        {
            return BadRequest();
        }

        var user = await _userManager.GetUserAsync(User);
        if (user.Id != game.PublisherId)
        {
            return Unauthorized();
        }
        
        string releaseDateString = model.ReleasedOn;
        if (!DateTime.TryParseExact(releaseDateString, ReleaseDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime releaseDate))
        {
            return BadRequest();
        }
        
        game.Title = model.Title;
        game.ImageUrl = model.ImageUrl;
        game.Description = model.Description;
        game.ReleasedOn = releaseDate;
        game.GenreId = model.GenreId;
        
        await _context.SaveChangesAsync();
        return RedirectToAction("All");
    }

    public async Task<IActionResult> StrikeOut(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        
        var gamerGames = await _context.GamersGames
            .FirstOrDefaultAsync(gg => gg.GamerId == user.Id && gg.GameId == id);

        if (gamerGames is null)
        {
            return BadRequest();
        }
        
        _context.GamersGames.Remove(gamerGames);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("MyZone");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var game = await _context.Games
            .Where(g => g.Id == id)
            .Select(g => new GameDetailsViewModel()
            {
                Id = g.Id,
                Title = g.Title,
                Description = g.Description,
                Genre = g.Genre.Name,
                ReleasedOn = g.ReleasedOn.ToString(ReleaseDateFormat),
                Publisher = g.Publisher.UserName,
                ImageUrl = g.ImageUrl
            })
            .FirstOrDefaultAsync();

        if (game is null)
        {
            return BadRequest();
        }
        
        return View(game);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var game = await _context.Games
            .Where(g => g.Id == id)
            .Select(g => new DeleteGameViewModel()
            {
                Id = g.Id,
                Publisher = g.Publisher.UserName,
                Title = g.Title,
            })
            .FirstOrDefaultAsync();
        
        if (game is null)
        {
            return BadRequest();
        }

        return View(game);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var game = await _context.Games
            .FirstOrDefaultAsync(g => g.Id == id);

        if (game is null)
        {
            return BadRequest();
        }
        
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();
        
        return RedirectToAction(nameof(All));
    }
}