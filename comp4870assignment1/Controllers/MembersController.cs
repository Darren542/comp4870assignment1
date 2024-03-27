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
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace assignment1.Controllers;

    [Authorize(Roles = "Admin")]
    public class MembersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MembersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Members
        public async Task<IActionResult> Index()
        {
            return View(await _context.Members.ToListAsync());
        }

        // GET: Members/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Members/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Members/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Mobile,Street,City,PostalCode,Country,Created,Modified,CreatedBy,ModifiedBy,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Members/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Members/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("FirstName,LastName,Mobile,Street,City,PostalCode,Country,Created,Modified,CreatedBy,ModifiedBy,Id,UserName,NormalizedUserName,Email,NormalizedEmail,EmailConfirmed,PasswordHash,SecurityStamp,ConcurrencyStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnd,LockoutEnabled,AccessFailedCount")] Member member)
        {   
            if (!await ValidateEmail(member))
            {
                return View(member);
            }
            var memberToUpdate = await _context.Members.FindAsync(id);
            if (memberToUpdate == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                memberToUpdate.FirstName = member.FirstName;
                memberToUpdate.LastName = member.LastName;
                memberToUpdate.Mobile = member.Mobile;
                memberToUpdate.Street = member.Street;
                memberToUpdate.City = member.City;
                memberToUpdate.PostalCode = member.PostalCode;
                memberToUpdate.Country = member.Country;
                memberToUpdate.Modified = DateTime.Now;
                memberToUpdate.ModifiedBy = User.Identity!.Name;
                memberToUpdate.UserName = member.Email;
                memberToUpdate.Email = member.Email;
                memberToUpdate.NormalizedEmail = member.Email!.ToUpper();
                memberToUpdate.NormalizedUserName = member.Email.ToUpper();
                try
                {
                    _context.Update(memberToUpdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.Id))
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
            
            return View(member);
        }

        private async Task<bool> ValidateEmail(Member member)
        {
            if (string.IsNullOrEmpty(member.Email))
            {
                ModelState.AddModelError("Email", "Email is required.");
                return false;
            } else {
                // Check if email is already in use by another member, not including the current member
                var memberWithEmail = await _context.Members.FirstOrDefaultAsync(m => m.Email == member.Email && m.Id != member.Id);
                if (memberWithEmail != null)
                {
                    ModelState.AddModelError("Email", "Email is already in use.");
                    return false;
                }
            }

            return true;
        }

        // GET: Members/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.Id == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Members/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(string id)
        {
            return _context.Members.Any(e => e.Id == id);
        }
    }
