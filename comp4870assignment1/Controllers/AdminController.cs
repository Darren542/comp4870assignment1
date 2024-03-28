using ClassLibrary;
using ClassLibrary.Data;
using ClassLibrary.Models;
using iText.IO.Font;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace assignment1;

public class AdminController : Controller
{
    private readonly UserManager<Member> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly ApplicationDbContext _context;

    public AdminController(UserManager<Member> userManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
    {
        _userManager = userManager;
        _roleManager = roleManager;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var users = _userManager.Users.ToList();
        var userRolesViewModel = new List<UserRoleViewModel>();

        foreach (Member user in users)
        {
            var thisViewModel = new UserRoleViewModel();
            thisViewModel.UserId = user.Id;
            thisViewModel.UserName = user.UserName;
            thisViewModel.Roles = _roleManager.Roles.Select(r => new SelectListItem
            {
                Text = r.Name,
                Value = r.Name
            });
            thisViewModel.CurrentRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();

            userRolesViewModel.Add(thisViewModel);
        }

        return View(userRolesViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUserRoles(string userId, string newRole)
    {
        Console.WriteLine("userId: " + userId);
        Console.WriteLine("newRole: " + newRole);
        var user = await _context.Members.FindAsync(userId);
        if (user != null)
        {
            var currentRoles = await _userManager.GetRolesAsync(user);
            await _userManager.RemoveFromRolesAsync(user, currentRoles);
            var result = await _userManager.AddToRoleAsync(user, newRole);

            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View("Index");
    }

}

