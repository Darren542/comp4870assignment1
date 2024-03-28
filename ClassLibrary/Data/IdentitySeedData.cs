using ClassLibrary.Models;
using Microsoft.AspNetCore.Identity;

namespace ClassLibrary.Data;

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
                Mobile = "1234567890",
                Street = "1234 Main St",
                City = "Anytown",
                PostalCode = "12345",
                Country = "USA",
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
                Mobile = "1234567890",
                Street = "1234 Main St",
                City = "Anytown",
                PostalCode = "12345",
                Country = "USA",
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

        if (await userManager.FindByNameAsync("p@p.p") == null) {
            var passenger = new Member
            {
                UserName = "p@p.p",
                Email = "p@p.p",
                FirstName = "Passenger",
                LastName = "User",
                Mobile = "1234567890",
                Street = "1234 Main St",
                City = "Anytown",
                PostalCode = "12345",
                Country = "USA",
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

        var adminUser = await userManager.FindByNameAsync("b@b.b");
        if (adminUser != null && adminUser.Mobile == null) {
            adminUser.Mobile = "1234567890";
            adminUser.Street = "1234 Main St";
            adminUser.City = "Anytown";
            adminUser.PostalCode = "12345";
            adminUser.Country = "USA";
            var result = await userManager.UpdateAsync(adminUser);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(adminUser, password4all);
                await userManager.AddToRoleAsync(adminUser, adminRole);
            }
        }

        var ownerUser = await userManager.FindByNameAsync("c@c.c");
        if (ownerUser != null && ownerUser.Mobile == null) {
            ownerUser.Mobile = "1234567890";
            ownerUser.Street = "1234 Main St";
            ownerUser.City = "Anytown";
            ownerUser.PostalCode = "12345";
            ownerUser.Country = "USA";
            var result = await userManager.UpdateAsync(ownerUser);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(ownerUser, password4all);
                await userManager.AddToRoleAsync(ownerUser, ownerRole);
            }
        }

        var passengerUser = await userManager.FindByNameAsync("d@d.d");
        if (passengerUser != null && passengerUser.Mobile == null) {
            passengerUser.Mobile = "1234567890";
            passengerUser.Street = "1234 Main St";
            passengerUser.City = "Anytown";
            passengerUser.PostalCode = "12345";
            passengerUser.Country = "USA";
            var result = await userManager.UpdateAsync(passengerUser);
            if (result.Succeeded) {
                await userManager.AddPasswordAsync(passengerUser, password4all);
                await userManager.AddToRoleAsync(passengerUser, passengerRole);
            }
        }
    }
}
