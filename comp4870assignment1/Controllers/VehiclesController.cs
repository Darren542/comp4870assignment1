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
using System.Security.Claims;

namespace assignment1.Controllers;

    [Authorize(Roles = "Admin, Owner")]
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        private readonly UserManager<Member> _userManager;

        public VehiclesController(ApplicationDbContext context, UserManager<Member> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Vehicles
        public async Task<IActionResult> Index()
        {
            return View(await _context.Vehicles.ToListAsync());
        }

        // GET: Vehicles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Member)
                .Include(v => v.CreatedByMember)
                .Include(v => v.ModifiedByMember)
                .FirstOrDefaultAsync(m => m.VehicleId == id);

            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // GET: Vehicles/Create
        public IActionResult Create()
        {
            // Make a viewbag of the users that are Admin or Owner
            var adminUsers = _userManager.GetUsersInRoleAsync("Admin").Result;
            var ownerUsers = _userManager.GetUsersInRoleAsync("Owner").Result;

            var adminAndOwnerUsers = adminUsers.Concat(ownerUsers).Distinct();

            ViewData["MemberId"] = new SelectList(adminAndOwnerUsers
                .Select(m => new { m.Id, Description = m.FirstName + " " + m.LastName + " [" + m.Email + "]" }), 
                "Id", "Description");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehicleId,Model,Make,Year,NumberOfSeats,VehicleType,MemberId,Created,Modified,CreatedBy,ModifiedBy")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle == null)
            {
                return NotFound();
            }
            var adminUsers = await _userManager.GetUsersInRoleAsync("Admin");
            var ownerUsers = await _userManager.GetUsersInRoleAsync("Owner");

            var adminAndOwnerUsers = adminUsers.Concat(ownerUsers).Distinct();

            ViewData["MemberId"] = new SelectList(adminAndOwnerUsers
                .Select(m => new { m.Id, Description = m.FirstName + " " + m.LastName + " [" + m.Email + "]" }), 
                "Id", "Description");
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VehicleId,Model,Make,Year,NumberOfSeats,VehicleType,MemberId,Created,Modified,CreatedBy,ModifiedBy")] Vehicle vehicle)
        {
            if (id != vehicle.VehicleId)
            {
                return NotFound();
            }

            var existingVehicle = await _context.Vehicles.FindAsync(id);
            if (existingVehicle == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Update the fields manually
                    existingVehicle.Model = vehicle.Model;
                    existingVehicle.Make = vehicle.Make;
                    existingVehicle.Year = vehicle.Year;
                    existingVehicle.NumberOfSeats = vehicle.NumberOfSeats;
                    existingVehicle.VehicleType = vehicle.VehicleType;
                    existingVehicle.MemberId = vehicle.MemberId;

                    // Update the Modified and ModifiedBy fields
                    existingVehicle.Modified = DateTime.Now;
                    existingVehicle.ModifiedBy = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                    _context.Update(existingVehicle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExists(vehicle.VehicleId))
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
            ViewData["MemberId"] = new SelectList(_context.Members
            .Select(m => new { m.Id, Description = m.FirstName + " " + m.LastName + " [" + m.Email + "]" }), 
            "Id", "Description"); 
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vehicle = await _context.Vehicles
                .Include(v => v.Member)
                .Include(v => v.CreatedByMember)
                .Include(v => v.ModifiedByMember)
                .FirstOrDefaultAsync(m => m.VehicleId == id);
            if (vehicle == null)
            {
                return NotFound();
            }

            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vehicle = await _context.Vehicles.FindAsync(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExists(int id)
        {
            return _context.Vehicles.Any(e => e.VehicleId == id);
        }
    }
