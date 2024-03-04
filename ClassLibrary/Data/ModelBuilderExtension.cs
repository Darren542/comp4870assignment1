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
        // Seed Vehicles
        modelBuilder.Entity<Vehicle>().HasData(
            GetVehicles()
        );

        // Seed Trips
        modelBuilder.Entity<Trip>().HasData(
            GetTrips()
        );

        // Seed Manifests
        modelBuilder.Entity<Manifest>().HasData(
            GetManifests()
        );
    }

    public static List<Vehicle> GetVehicles() {
        var ownerId = "ffc343dc-373e-42d6-9460-4a8c2c8b8275";
        
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

    public static List<Trip> GetTrips() {
        var ownerId = "ffc343dc-373e-42d6-9460-4a8c2c8b8275";

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
    
    public static List<Manifest> GetManifests() {
        var ownerId = "ffc343dc-373e-42d6-9460-4a8c2c8b8275";

        List<Manifest> manifests = new List<Manifest>() {
            new Manifest {
                ManifestId = 1,
                MemberId = "36204d2a-d455-4eaf-9613-46826bba2a3b",
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
                MemberId = "f824f67c-1b68-4c00-b8b8-289de93f2d79",
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
                MemberId = "36204d2a-d455-4eaf-9613-46826bba2a3b",
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
