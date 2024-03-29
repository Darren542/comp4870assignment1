using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data;

public class VehicleService
{
     private ApplicationDbContext _context;
     public VehicleService(ApplicationDbContext context)
     {
          _context = context;
     }
     public async Task<List<Vehicle>> GetVehiclesAsync()
     {
          return await _context.Vehicles.ToListAsync();
     }
     public async Task<Vehicle?> GetVehicleAsync(int id)
     {
          return await _context.Vehicles.FindAsync(id);
     }
     public async Task<Vehicle> AddVehicleAsync(Vehicle vehicle)
     {
          _context.Vehicles.Add(vehicle);
          await _context.SaveChangesAsync();
          return vehicle;
     }
     public async Task<Vehicle?> UpdateVehicleAsync(int id, Vehicle vehicle)
     {
          var Vehicle = await _context.Vehicles.FindAsync(id);

          if(Vehicle == null)
          {
               return null;
          }

          Vehicle.VehicleId = vehicle.VehicleId;
          Vehicle.Model = vehicle.Model;
          Vehicle.Make = vehicle.Make;
          Vehicle.Year = vehicle.Year;
          Vehicle.NumberOfSeats = vehicle.NumberOfSeats;
          Vehicle.VehicleType = vehicle.VehicleType;

          _context.Vehicles.Update(vehicle);
          await _context.SaveChangesAsync();
          return vehicle;
     }
     public async Task<Vehicle?> DeleteVehicleAsync(int id)
     {
          var vehicle = _context.Vehicles.FirstOrDefault(x => x.VehicleId == id);
          if (vehicle == null)
          {
               return null;
          }
          _context.Vehicles.Remove(vehicle);
          await _context.SaveChangesAsync();
          return vehicle;
     }
}
