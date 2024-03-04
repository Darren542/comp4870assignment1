using ClassLibrary.Models;
using Microsoft.AspNetCore.Identity;

namespace ClassLibrary.Data
{
    public static class IdentitySeedData {
    public static async Task Initialize(ApplicationDbContext context,
        UserManager<Member> userManager,
        RoleManager<IdentityRole> roleManager) {
        context.Database.EnsureCreated();

        string adminRole = "Admin";
        string ownerRole = "Owner";
        string passengerRole = "Passenger";
        string password4all = "P@$$w0rd";

        if (await roleManager.FindByNameAsync(adminRole) == null) {
            await roleManager.CreateAsync(new IdentityRole(adminRole));
        }

        if (await roleManager.FindByNameAsync(ownerRole) == null) {
            await roleManager.CreateAsync(new IdentityRole(ownerRole));
        }

        if (await roleManager.FindByNameAsync(passengerRole) == null) {
            await roleManager.CreateAsync(new IdentityRole(passengerRole));
        }

        if (await userManager.FindByNameAsync("a@a.a") == null){
            var admin = new Member
            {
                UserName = "a@a.a",
                Email = "a@a.a",
                FirstName = "Admin",
                LastName = "User",
                EmailConfirmed = true,
                NormalizedUserName = "A@A.A",
                NormalizedEmail = "A@A.A",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            var result = await userManager.CreateAsync(admin);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(admin, password4all);
                await userManager.AddToRoleAsync(admin, adminRole);
            }
        }

        if (await userManager.FindByNameAsync("o@o.o") == null) {
            var owner = new Member
            {
                UserName = "o@o.o",
                Email = "o@o.o",
                FirstName = "Owner",
                LastName = "User",
                EmailConfirmed = true,
                NormalizedUserName = "O@O.O",
                NormalizedEmail = "O@O.O",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            var result = await userManager.CreateAsync(owner);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(owner, password4all);
                await userManager.AddToRoleAsync(owner, ownerRole);
            }
        }

        if (await userManager.FindByNameAsync("mm@mm.mm") == null) {
            var passenger = new Member
            {
                UserName = "p@p.p",
                Email = "p@p.p",
                FirstName = "Passenger",
                LastName = "User",
                EmailConfirmed = true,
                NormalizedUserName = "P@P.P",
                NormalizedEmail = "P@P.P",
                SecurityStamp = Guid.NewGuid().ToString("D"),
            };

            var result = await userManager.CreateAsync(passenger);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(passenger, password4all);
                await userManager.AddToRoleAsync(passenger, passengerRole);
            }
        }
    }
}
}