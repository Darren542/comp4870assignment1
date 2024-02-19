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

namespace assignment1.Controllers;

    [Authorize(Roles = "Admin")]
    public class ManifestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ManifestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Manifests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Manifests.Include(m => m.Member).Include(m => m.Trip).Include(m => m.Vehicle);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Manifests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manifest = await _context.Manifests
                .Include(m => m.Member)
                .Include(m => m.Trip)
                .Include(m => m.Vehicle)
                .FirstOrDefaultAsync(m => m.ManifestId == id);
            if (manifest == null)
            {
                return NotFound();
            }

            return View(manifest);
        }

        // GET: Manifests/Create
        public IActionResult Create()
        {
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id");
            ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId");
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "MemberId");
            return View();
        }

        // POST: Manifests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ManifestId,MemberId,TripId,VehicleId,Notes,Created,Modified,CreatedBy,ModifiedBy")] Manifest manifest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manifest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", manifest.MemberId);
            ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", manifest.TripId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "MemberId", manifest.VehicleId);
            return View(manifest);
        }

        // GET: Manifests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manifest = await _context.Manifests.FindAsync(id);
            if (manifest == null)
            {
                return NotFound();
            }
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", manifest.MemberId);
            ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", manifest.TripId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "MemberId", manifest.VehicleId);
            return View(manifest);
        }

        // POST: Manifests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ManifestId,MemberId,TripId,VehicleId,Notes,Created,Modified,CreatedBy,ModifiedBy")] Manifest manifest)
        {
            if (id != manifest.ManifestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manifest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManifestExists(manifest.ManifestId))
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
            ViewData["MemberId"] = new SelectList(_context.Members, "Id", "Id", manifest.MemberId);
            ViewData["TripId"] = new SelectList(_context.Trips, "TripId", "TripId", manifest.TripId);
            ViewData["VehicleId"] = new SelectList(_context.Vehicles, "VehicleId", "MemberId", manifest.VehicleId);
            return View(manifest);
        }

        // GET: Manifests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manifest = await _context.Manifests
                .Include(m => m.Member)
                .Include(m => m.Trip)
                .Include(m => m.Vehicle)
                .FirstOrDefaultAsync(m => m.ManifestId == id);
            if (manifest == null)
            {
                return NotFound();
            }

            return View(manifest);
        }

        // POST: Manifests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manifest = await _context.Manifests.FindAsync(id);
            if (manifest != null)
            {
                _context.Manifests.Remove(manifest);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManifestExists(int id)
        {
            return _context.Manifests.Any(e => e.ManifestId == id);
        }
    }
