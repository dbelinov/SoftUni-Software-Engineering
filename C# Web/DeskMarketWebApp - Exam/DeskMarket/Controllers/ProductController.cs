using System.Globalization;
using DeskMarket.Data;
using DeskMarket.Data.Models;
using DeskMarket.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static DeskMarket.Common.ValidationConstants.ProductValidationConstants;

namespace DeskMarket.Controllers;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public ProductController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var products = await _context.Products
            .Include(p => p.ProductsClients)
            .ToListAsync();
        
        var user = await _userManager.GetUserAsync(HttpContext.User);
        
        var model = products
            .Where(p => p.IsDeleted == false)
            .Select(p => new ProductViewModel()
            {
                ProductName = p.ProductName,
                Price = p.Price,
                HasBought = p.ProductsClients.Any(pc => pc.ClientId == user?.Id),
                IsSeller = p.SellerId == user?.Id,
                ImageUrl = p.ImageUrl,
                Id = p.Id,
            })
            .ToList();
        
        return View(model);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Add()
    {
        var categories = await _context.Categories
            .ToListAsync();

        var model = new ProductFormViewModel()
        {
            Categories = categories
        }; 
        
        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Add(ProductFormViewModel model)
    {
        if (!DateTime.TryParseExact(model.AddedOn, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var validDate))
        {
            ModelState.AddModelError("AddedOn", "Invalid date");
        } 
        
        if (!ModelState.IsValid)
        {
            var categories = await _context.Categories
                .ToListAsync();
            
            var newModel = model;
            newModel.Categories = categories;
            
            return View(newModel);
        }

        var user = await _userManager.GetUserAsync(User);
        
        Product product = new Product()
        {
            Id = model.Id,
            ProductName = model.ProductName,
            Description = model.Description,
            Price = model.Price,
            ImageUrl = model.ImageUrl,
            AddedOn = validDate,
            CategoryId = model.CategoryId,
            SellerId = user.Id
        };
        
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Cart()
    {
        var user = await _userManager.GetUserAsync(User);

        var products = await _context.ProductsClients
            .Where(pc => pc.ClientId == user.Id && pc.Product.IsDeleted == false)
            .Select(pc => new ProductCartViewModel()
            {
                Id = pc.ProductId,
                ImageUrl = pc.Product.ImageUrl,
                Price = pc.Product.Price,
                ProductName = pc.Product.ProductName,
            })
            .ToListAsync();
        
        return View(products);
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null || user?.Id != product.SellerId)
        {
            return RedirectToAction("Index");
        }
        
        var categories = await _context.Categories
            .ToListAsync();

        var model = new ProductFormViewModel()
        {
            ProductName = product.ProductName,
            Price = product.Price,
            Description = product.Description,
            ImageUrl = product.ImageUrl,
            AddedOn = product.AddedOn.ToString(DateFormat),
            CategoryId = product.CategoryId,
            Categories = categories,
            Id = product.Id,
            SellerId = product.SellerId
        };
        
        
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(ProductFormViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == model.Id);
        
        if (product is null || user?.Id != product.SellerId)
        {
            ModelState.AddModelError("input", "Invalid input");
        }

        if (!DateTime.TryParseExact(model.AddedOn, DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var validDate))
        {
            ModelState.AddModelError("AddedOn", "Invalid date");
        }

        if (!ModelState.IsValid)
        {
            var categories = await _context.Categories
                .ToListAsync();

            var newModel = model;
            newModel.Categories = categories;
            
            return View(newModel);
        }
        
        product.ProductName = model.ProductName;
        product.Price = model.Price;
        product.Description = model.Description;
        product.ImageUrl = model.ImageUrl;
        product.AddedOn = validDate;
        product.CategoryId = model.CategoryId;

        await _context.SaveChangesAsync();

        return RedirectToAction("Details", new { id = product.Id });
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddToCart(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return RedirectToAction("Index");
        }

        if (_context.ProductsClients.Any(pc => pc.ClientId == user.Id && pc.ProductId == id))
        {
            return RedirectToAction("Index");
        }

        ProductClient productClient = new ProductClient()
        {
            ClientId = user.Id,
            ProductId = id
        };
        
        await _context.ProductsClients.AddAsync(productClient);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> RemoveFromCart(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        var productClient = await _context.ProductsClients
            .FirstOrDefaultAsync(pc => pc.ProductId == id && pc.ClientId == user.Id);

        if (productClient is null)
        {
            return RedirectToAction("Cart");
        }

        _context.ProductsClients.Remove(productClient);
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Cart");
    }

    [HttpGet]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _context.Products
            .Include(p => p.ProductsClients)
            .Include(p => p.Category)
            .Include(p => p.Seller)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null)
        {
            return RedirectToAction("Index");
        }
        
        var user = await _userManager.GetUserAsync(User);

        var model = new ProductDetailsViewModel()
        {
            Id = product.Id,
            ProductName = product.ProductName,
            AddedOn = product.AddedOn.ToString(DateFormat),
            CategoryName = product.Category.Name,
            Description = product.Description,
            HasBought = product.ProductsClients.Any(pc => pc.ClientId == user?.Id),
            ImageUrl = product.ImageUrl,
            Price = product.Price,
            Seller = product.Seller.UserName,
        };

        return View(model);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> Delete(int id)
    {
        var user = await _userManager.GetUserAsync(User);
        var product = await _context.Products
            .Include(p => p.Seller)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (product is null || product.SellerId != user.Id)
        {
            return RedirectToAction("Index");
        }

        var model = new ProductDeleteViewModel()
        {
            Id = product.Id,
            ProductName = product.ProductName,
            Seller = product.Seller.UserName,
            SellerId = product.SellerId,
        };
        
        return View(model);
    }

    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Delete(int id, ProductDeleteViewModel model)
    {
        var user = await _userManager.GetUserAsync(User);
        var product = await _context.Products
            .FirstOrDefaultAsync(p => p.Id == id);
        
        if (product is null || product.SellerId != user.Id)
        {
            return RedirectToAction("Index");
        }
        
        product.IsDeleted = true;
        await _context.SaveChangesAsync();
        
        return RedirectToAction("Index");
    }
}