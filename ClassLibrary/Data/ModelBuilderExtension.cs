using ClassLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ClassLibrary;

public static class ModelBuilderExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        // Seed default roles with explicit IDs
        var roles = new List<IdentityRole>
        {
            new IdentityRole { Id = "a1b2c3d4", Name = "Admin", NormalizedName = "ADMIN"},
            new IdentityRole { Id = "e5f6g7h8", Name = "Member", NormalizedName = "MEMBER"}
        };

        modelBuilder.Entity<IdentityRole>().HasData(roles);

        var passwordHasher = new PasswordHasher<Member>();

        // Seed Members with static IDs
        var admin = new Member
        {
            Id = "1", // Static Id for seeding purposes, we can change this if it becomes a problem
            UserName = "admin@example.com",
            Email = "admin@example.com",
            FirstName = "Admin",
            LastName = "User",
            EmailConfirmed = true,
            NormalizedUserName = "ADMIN@EXAMPLE.COM",
            NormalizedEmail = "ADMIN@EXAMPLE.COM",
            SecurityStamp = Guid.NewGuid().ToString("D"),
        };
        admin.PasswordHash = passwordHasher.HashPassword(admin, "AdminPassword123!");

        var member = new Member
        {
            Id = "2", // Static Id for seeding purposes
            UserName = "member@example.com",
            Email = "member@example.com",
            FirstName = "Member",
            LastName = "User",
            EmailConfirmed = true,
            NormalizedUserName = "MEMBER@EXAMPLE.COM",
            NormalizedEmail = "MEMBER@EXAMPLE.COM",
            SecurityStamp = Guid.NewGuid().ToString("D"),
        };
        member.PasswordHash = passwordHasher.HashPassword(member, "MemberPassword123!");

        modelBuilder.Entity<Member>().HasData(admin, member);

        // Seed UserRoles
        var userRoles = new List<IdentityUserRole<string>>
        {
            new IdentityUserRole<string> { UserId = admin.Id, RoleId = "a1b2c3d4" }, // Assigning Admin role to admin user
            new IdentityUserRole<string> { UserId = member.Id, RoleId = "e5f6g7h8" }  // Assigning Member role to member user
        };

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(userRoles);
    }
}
