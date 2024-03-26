using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClassLibrary.Data;
using ClassLibrary.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace assignment1.Controllers;

    [Authorize(Roles = "Admin, Owner")]
    public class TripsController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<Member> _userManager;


        public TripsController(ApplicationDbContext context, UserManager<Member> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Trips
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Trips.Include(t => t.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Trips/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .Include(t => t.Vehicle)
                .FirstOrDefaultAsync(m => m.TripId == id);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // GET: Trips/Create
        public IActionResult Create()
        {
            ViewData["VehicleId"] = new SelectList(_context.Vehicles
                .Select(v => new { v.VehicleId, Description = v.Make + " " + v.Model }), 
                "VehicleId", "Description");
            return View();
        }

        // POST: Trips/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,Date,Time,DestinationAddress,MeetingAddress")] Trip trip)
        {
            if (ModelState.IsValid)
            {
                string? userId = _userManager.GetUserId(User);
                Trip newTrip = new()
                {
                    VehicleId = trip.VehicleId,
                    Date = trip.Date,
                    Time = trip.Time,
                    DestinationAddress = trip.DestinationAddress,
                    MeetingAddress = trip.MeetingAddress,
                    Created = DateTime.Now,
                    Modified = DateTime.Now,
                    CreatedBy = userId,
                    ModifiedBy = userId
                };
                _context.Add(newTrip);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", trip.VehicleId);
            return View(trip);
        }

        // GET: Trips/Edit/5
        public async Task<IActionResult> Edit(int? tripId, int? vehicleId)
        {
            if (tripId == null || vehicleId == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .FirstOrDefaultAsync(m => m.TripId == tripId && m.VehicleId == vehicleId);
            if (trip == null)
            {
                return NotFound();
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles
                .Select(v => new { v.VehicleId, Description = v.Make + " " + v.Model }), 
                "VehicleId", "Description");
            return View(trip);
        }

        // POST: Trips/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int tripId, int vehicleId, [Bind("TripId,VehicleId,Date,Time,DestinationAddress,MeetingAddress,Created,Modified,CreatedBy,ModifiedBy")] Trip trip)
        {
            if (tripId != trip.TripId || vehicleId != trip.VehicleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trip);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TripExists(trip.TripId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", trip.VehicleId);
            return View(trip);
        }

        // GET: Trips/Delete/5
        public async Task<IActionResult> Delete(int? tripId)
        {
            if (tripId == null)
            {
                return NotFound();
            }

            var trip = await _context.Trips
                .FirstOrDefaultAsync(m => m.TripId == tripId);
            if (trip == null)
            {
                return NotFound();
            }

            return View(trip);
        }

        // POST: Trips/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int tripId)
        {
            var trip = await _context.Trips
                .FirstOrDefaultAsync(m => m.TripId == tripId);
            if (trip != null)
            {
                _context.Trips.Remove(trip);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        private bool TripExists(int tripId)
        {
            return _context.Trips.Any(e => e.TripId == tripId);
        }
    }
