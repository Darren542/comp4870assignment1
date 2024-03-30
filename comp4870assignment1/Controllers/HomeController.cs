using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using assignment1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ClassLibrary.Models;
using ClassLibrary.Data;

namespace assignment1.Controllers;

[Authorize(Roles = "Admin, Owner, Passenger")]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;
    private readonly UserManager<Member> _userManager;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<Member> userManager)
    {
        _logger = logger;
        _context = context;
        _userManager = userManager;
    }

    public async Task<IActionResult> IndexAsync()
    {
        //Get current Date as DateOnly
        DateOnly date = DateOnly.FromDateTime(DateTime.Now);
        // Look in Manifests for Trips the current user is signed up for
        var userId = _userManager.GetUserId(User);
        var upcomingTrips = _context.Manifests
            .Where(m => m.MemberId == userId && m.Trip!.Date >= DateOnly.FromDateTime(DateTime.Today))
            .Include(m => m.Trip)
            .ThenInclude(t => t!.Vehicle)
            .Include(m => m.Trip)
            .ThenInclude(t => t!.Manifests)
            .OrderBy(m => m.Trip!.Date)
            .ToList();
        ViewData["UpcomingTrips"] = upcomingTrips;

        var availableTrips = _context.Trips
            .Where(t => t.Date >= date && !_context.Manifests.Any(m => m.TripId == t.TripId && m.MemberId == userId))
            .Include(t => t.Vehicle)
            .Include(t => t.Manifests)
            .ToList();
        return await Task.FromResult(View(availableTrips));
    }

    public IActionResult Search(DateOnly date)
    {
        var trips = _context.Trips.Where(t => t.Date == date).Include(t => t.Vehicle).ToList();
        return PartialView("_SearchResults", trips);
    }

    [HttpPost]
    public async Task<IActionResult> JoinTrip(int tripId)
    {
        // Get the current user
        var userId = _userManager.GetUserId(User);

        // Find ManifestId with the same TripId
        var manifest = _context.Manifests.FirstOrDefault(m => m.TripId == tripId);
        int nextManifestId = _context.Manifests
            .DefaultIfEmpty()
            .Max(m => (int?)m!.ManifestId) + 1 ?? 1;

        Manifest newManifest = new()
        {
            ManifestId = manifest != null ? manifest.ManifestId : nextManifestId,
            MemberId = userId,
            TripId = tripId,
            Created = DateTime.Now,
            Modified = DateTime.Now,
            CreatedBy = userId,
            ModifiedBy = userId
        };

        _context.Manifests.Add(newManifest);

        // Save changes
        await _context.SaveChangesAsync();

        // Redirect back to the index page
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> CancelTrip(int manifestId)
    {
        // Get the current user
        var userId = _userManager.GetUserId(User);

        //Delete Manifest with the same ManifestId and MemberId
        var manifest = _context.Manifests.FirstOrDefault(m => m.ManifestId == manifestId && m.MemberId == userId);
        _context.Manifests.Remove(manifest!);

        // Save changes
        await _context.SaveChangesAsync();

        // Redirect back to the index page
        return RedirectToAction(nameof(Index));
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
