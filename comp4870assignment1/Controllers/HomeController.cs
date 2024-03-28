using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using assignment1.Models;
using Microsoft.AspNetCore.Authorization;
using ClassLibrary.Data;
using Microsoft.EntityFrameworkCore;

namespace assignment1.Controllers;

[Authorize(Roles = "Admin, Owner, Passenger")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> IndexAsync()
    {
        //Get current Date as DateOnly
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        var applicationDbContext = _context.Trips.Where(t => t.Date >= date).Include(t => t.Vehicle);
        return View(await applicationDbContext.ToListAsync());
    }

    public IActionResult Search(DateOnly date)
    {
        var trips = _context.Trips.Where(t => t.Date == date).Include(t => t.Vehicle).ToList();
        return PartialView("_SearchResults", trips);
    }

    [Authorize(Roles = "Admin, Owner")]
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
