using DeskMarket.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using DeskMarket.Data.Models;

namespace DeskMarket.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            if (User?.Identity?.IsAuthenticated is true)
            {
                return RedirectToAction("Index", "Product");
            }
            
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
