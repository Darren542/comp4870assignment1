using ClassLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ClassLibrary.Data;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        var pwd = "P@$$w0rd";
        // Seed default roles with explicit IDs
        var roles = new List<IdentityRole>
        {
            new IdentityRole("Admin"),
            new IdentityRole("Owner"),
            new IdentityRole("Passenger")
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);

        var passwordHasher = new PasswordHasher<Member>();

        // Seed Members with static IDs
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
        admin.PasswordHash = passwordHasher.HashPassword(admin, pwd);

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
        owner.PasswordHash = passwordHasher.HashPassword(owner, pwd);

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
        passenger.PasswordHash = passwordHasher.HashPassword(passenger, pwd);

        List<Member> users = new List<Member>() { admin, owner, passenger };

        modelBuilder.Entity<Member>().HasData(users);

        // Seed UserRoles
        List<IdentityUserRole<string>> userRoles = new List<IdentityUserRole<string>>();
        
        userRoles.Add(new IdentityUserRole<string> {
            UserId = users[0].Id,
            RoleId = roles.First(q => q.Name == "Admin").Id
        });

        userRoles.Add(new IdentityUserRole<string> {
            UserId = users[1].Id,
            RoleId = roles.First(q => q.Name == "Owner").Id
        });

        userRoles.Add(new IdentityUserRole<string> {
            UserId = users[2].Id,
            RoleId = roles.First(q => q.Name == "Passenger").Id
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}
