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

        //Look through users list and get their user.Id and make it into a new list
        List<string> userIds = users.Select(q => q.Id).ToList();

        // Seed Vehicles
        modelBuilder.Entity<Vehicle>().HasData(
            GetVehicles(userIds)
        );

        // Seed Trips
        modelBuilder.Entity<Trip>().HasData(
            GetTrips(userIds)
        );

        // Seed Manifests
        modelBuilder.Entity<Manifest>().HasData(
            GetManifests(userIds)
        );
    }

    public static List<Vehicle> GetVehicles(List<string> userIds) {
        var ownerId = userIds[1];
        
        List<Vehicle> vehicles = new List<Vehicle>() {
            new Vehicle {
                VehicleId = 1,
                Model = "Model 3",
                Make = "Tesla",
                Year = 2021,
                NumberOfSeats = 5,
                VehicleType = "Electric",
                MemberId = ownerId,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Vehicle {
                VehicleId = 2,
                Model = "Model S",
                Make = "Tesla",
                Year = 2021,
                NumberOfSeats = 5,
                VehicleType = "Electric",
                MemberId = ownerId,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Vehicle {
                VehicleId = 3,
                Model = "Model X",
                Make = "Tesla",
                Year = 2021,
                NumberOfSeats = 5,
                VehicleType = "Electric",
                MemberId = ownerId,
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            }
        };

        return vehicles;
    }

    public static List<Trip> GetTrips(List<string> userIds) {
        var ownerId = userIds[1];

        List<Trip> trips = new List<Trip>() {
            new Trip {
                TripId = 1,
                VehicleId = 1,
                Date = new DateOnly(2021, 12, 25),
                Time = new TimeOnly(12, 0, 0),
                DestinationAddress = "123 Main St, Anytown, USA",
                MeetingAddress = "456 Elm St, Anytown, USA",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Trip {
                TripId = 2,
                VehicleId = 2,
                Date = new DateOnly(2022, 1, 12),
                Time = new TimeOnly(14, 30, 0),
                DestinationAddress = "321 Knight St, Anytown, USA",
                MeetingAddress = "789 Cambie St, Anytown, USA",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Trip {
                TripId = 3,
                VehicleId = 3,
                Date = new DateOnly(2022, 1, 24),
                Time = new TimeOnly(8, 0, 0),
                DestinationAddress = "8 Moody St, Anyville, USA",
                MeetingAddress = "99 Hastings St, Anytown, USA",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            }
        };

        return trips;
    }
    
    public static List<Manifest> GetManifests(List<string> userIds) {
        var ownerId = userIds[1];

        List<Manifest> manifests = new List<Manifest>() {
            new Manifest {
                ManifestId = 1,
                MemberId = userIds[2],
                TripId = 1,
                VehicleId = 1,
                Notes = "I'm driving",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Manifest {
                ManifestId = 2,
                MemberId = userIds[0],
                TripId = 2,
                VehicleId = 2,
                Notes = "I'm driving",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Manifest {
                ManifestId = 3,
                MemberId = userIds[2],
                TripId = 3,
                VehicleId = 3,
                Notes = "I'm driving",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            }
        };

        return manifests;
    }
}
