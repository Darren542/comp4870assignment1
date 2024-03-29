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
        var passwordHasher = new PasswordHasher<Member>();
        var user1 = new Member
        {
            UserName = "b@b.b",
            Email = "b@b.b",
            FirstName = "Test",
            LastName = "User1",
            EmailConfirmed = true,
            NormalizedUserName = "B@B.B",
            NormalizedEmail = "B@B.B",
            SecurityStamp = Guid.NewGuid().ToString("D"),
        };
        user1.PasswordHash = passwordHasher.HashPassword(user1, pwd);

        var user2 = new Member
        {
            UserName = "c@c.c",
            Email = "c@c.c",
            FirstName = "Test",
            LastName = "Owner",
            EmailConfirmed = true,
            NormalizedUserName = "C@C.C",
            NormalizedEmail = "C@C.C",
            SecurityStamp = Guid.NewGuid().ToString("D"),
        };
        user2.PasswordHash = passwordHasher.HashPassword(user2, pwd);

        var user3 = new Member
        {
            UserName = "d@d.d",
            Email = "d@d.d",
            FirstName = "Test",
            LastName = "Passenger",
            EmailConfirmed = true,
            NormalizedUserName = "D@D.D",
            NormalizedEmail = "D@D.D",
            SecurityStamp = Guid.NewGuid().ToString("D"),
        };
        user3.PasswordHash = passwordHasher.HashPassword(user3, pwd);

        List<Member> users = new List<Member>() { user1, user2, user3 };

        modelBuilder.Entity<Member>().HasData(users);

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
                Date = new DateOnly(2024, 3, 10),
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
                Date = new DateOnly(2024, 4, 12),
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
                Date = new DateOnly(2024, 4, 13),
                Time = new TimeOnly(8, 0, 0),
                DestinationAddress = "8 Moody St, Anyville, USA",
                MeetingAddress = "99 Hastings St, Anytown, USA",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Trip {
                TripId = 4,
                VehicleId = 3,
                Date = new DateOnly(2022, 4, 13),
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
                Notes = "I'm driving",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Manifest {
                ManifestId = 4,
                MemberId = userIds[2],
                TripId = 4,
                Notes = "I'm driving",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Manifest {
                ManifestId = 5,
                MemberId = ownerId,
                TripId = 1,
                Notes = "I'm driving",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Manifest {
                ManifestId = 6,
                MemberId = ownerId,
                TripId = 2,
                Notes = "I'm driving",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Manifest {
                ManifestId = 7,
                MemberId = ownerId,
                TripId = 3,
                Notes = "I'm driving",
                Created = DateTime.Now,
                Modified = DateTime.Now,
                CreatedBy = ownerId,
                ModifiedBy = ownerId
            },
            new Manifest {
                ManifestId = 8,
                MemberId = ownerId,
                TripId = 4,
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
