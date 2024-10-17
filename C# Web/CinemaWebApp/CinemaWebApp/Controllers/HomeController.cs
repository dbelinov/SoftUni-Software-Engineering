using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CinemaWebApp.Models;

namespace CinemaWebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        ViewBag.Message = "Welcome to the Cinema Web App!";
        
        return View();
    }
}