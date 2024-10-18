using System.Globalization;
using Homies.Data;
using Homies.Models;
using Homies.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Homies.Common.ValidationConstants.EventValidationConstants;

namespace Homies.Controllers;

[Authorize]
public class EventController : Controller
{
    private readonly HomiesDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public EventController(HomiesDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    
    [HttpGet]
    public async Task<IActionResult> All()
    {
        var events = await _context.Events
            .Select(e => new EventViewModel()
            {
                Name = e.Name,
                Organiser = e.Organiser.UserName,
                Start = e.Start.ToString(EventDateFormat),
                Type = e.Type.Name,
                Id = e.Id,
            })
            .ToListAsync();
        
        return View(events);
    }

    [HttpGet]
    public async Task<IActionResult> Joined()
    {
        var user = await _userManager.GetUserAsync(User);

        var events = await _context.EventsParticipants
            .Where(ep => ep.HelperId == user.Id)
            .Include(ep => ep.Event)
            .Select(ep => new EventViewModel()
            {
                Name = ep.Event.Name,
                Start = ep.Event.Start.ToString(EventDateFormat),
                Type = ep.Event.Type.Name,
                Organiser = ep.Event.Organiser.UserName,
                Id = ep.Event.Id,
            })
            .ToListAsync();

        return View(events);
    }

    [HttpGet]
    public async Task<IActionResult> Add()
    {
        var types = await _context.Types
            .Select(t => new TypeViewModel()
            {
                Name = t.Name,
                Id = t.Id,
            })
            .ToListAsync();

        var model = new EventInputViewModel()
        {
            Types = types
        };
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Add(EventInputViewModel model)
    {
        string startDateTimeString = model.Start;
        string endDateTimeString = model.End;
        
        if (!DateTime.TryParseExact(startDateTimeString, EventDateFormat, CultureInfo.InvariantCulture,
                DateTimeStyles.None, out DateTime validStartDateTime) 
            || !DateTime.TryParse(endDateTimeString, CultureInfo.InvariantCulture, 
                DateTimeStyles.None, out DateTime validEndDateTime))
        {
            return RedirectToAction("Add");
        }
        
        var user = await _userManager.GetUserAsync(User);
        
        Event newEvent = new Event()
        {
            Name = model.Name,
            CreatedOn = DateTime.Now,
            Start = validStartDateTime,
            End = validEndDateTime,
            Description = model.Description,
            OrganiserId = user.Id,
            TypeId = model.TypeId,
            Id = model.Id,
        };
        
        await _context.Events.AddAsync(newEvent);
        await _context.SaveChangesAsync();

        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var types = await _context.Types
            .Select(t => new TypeViewModel()
            {
                Id = t.Id,
                Name = t.Name
            })
            .ToListAsync();
        
        var user = await _userManager.GetUserAsync(User);

        var foundEvent = await _context.Events
            .FirstOrDefaultAsync(e => e.Id == id);
        
        if (foundEvent is null)
        {
            return RedirectToAction("All");
        }

        if (user.Id != foundEvent.OrganiserId)
        {
            return RedirectToAction("All");
        }

        var model = new EventInputViewModel()
        {
            Name = foundEvent.Name,
            Description = foundEvent.Description,
            Start = foundEvent.Start.ToString(EventDateFormat),
            End = foundEvent.End.ToString(EventDateFormat),
            TypeId = foundEvent.TypeId,
            Types = types,
            Id = id
        };
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, EventInputViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);

        var foundEvent = await _context.Events
            .FirstOrDefaultAsync(e => e.Id == id);
        
        if (foundEvent is null)
        {
            return RedirectToAction("All");
        }

        if (user.Id != foundEvent.OrganiserId)
        {
            return RedirectToAction("All");
        }
        
        string startDateTimeString = model.Start;
        string endDateTimeString = model.End;

        if (!DateTime.TryParseExact(startDateTimeString, EventDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime startDateTime) 
            || !DateTime.TryParseExact(endDateTimeString, EventDateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime endDateTime))
        {
            return RedirectToAction("Edit");
        }

        foundEvent.Name = model.Name;
        foundEvent.Description = model.Description;
        foundEvent.Start = startDateTime;
        foundEvent.End = endDateTime;
        foundEvent.TypeId = model.TypeId;
        
        await _context.SaveChangesAsync();
        
        return RedirectToAction("All");
    }

    [HttpPost]
    public async Task<IActionResult> Join(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        
        var foundEvent = await _context.Events
            .FirstOrDefaultAsync(e => e.Id == id);

        if (foundEvent is null)
        {
            return RedirectToAction("All");
        }

        if (_context.EventsParticipants.Any(ep => ep.HelperId == user.Id && ep.EventId == foundEvent.Id))
        {
            return RedirectToAction("All");
        }

        EventParticipant eventParticipant = new EventParticipant()
        {
            EventId = foundEvent.Id,
            HelperId = user.Id,
        };

        await _context.EventsParticipants.AddAsync(eventParticipant);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Joined");
    }

    public async Task<IActionResult> Leave(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        var foundEventParticipant = await _context.EventsParticipants
            .FirstOrDefaultAsync(ep => ep.EventId == id && ep.HelperId == user.Id);

        if (foundEventParticipant is null)
        {
            return RedirectToAction("Joined");
        }
        
        _context.EventsParticipants.Remove(foundEventParticipant);
        await _context.SaveChangesAsync();

        return RedirectToAction("All");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var foundEvent = await _context.Events
            .Include(e => e.Organiser)
            .Include(e => e.Type)
            .FirstOrDefaultAsync(e => e.Id == id);

        if (foundEvent is null)
        {
            return RedirectToAction("All");
        }

        var model = new EventDetailsViewModel()
        {
            Id = foundEvent.Id,
            Name = foundEvent.Name,
            Description = foundEvent.Description,
            Start = foundEvent.Start.ToString(EventDateFormat),
            End = foundEvent.End.ToString(EventDateFormat),
            Organiser = foundEvent.Organiser.UserName,
            CreatedOn = foundEvent.CreatedOn.ToString(EventDateFormat),
            Type = foundEvent.Type.Name,
        };

        return View(model);
    }
}