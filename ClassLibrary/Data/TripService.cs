using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary.Data;

public class TripService
{
    private readonly ApplicationDbContext _context;

    public TripService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Trip>> GetTripsAsync()
    {
        return await _context.Trips.Include(t => t.Vehicle).ToListAsync();
    }

    public async Task<Trip> GetTripAsync(int id)
    {
        return await _context.Trips.FindAsync(id);
    }

    public async Task<Trip> AddTripAsync(Trip trip)
    {
        _context.Trips.Add(trip);
        await _context.SaveChangesAsync();
        return trip;
    }

    public async Task<Trip> UpdateTripAsync(int id, Trip trip)
    {
        var existingTrip = await _context.Trips.FindAsync(id);
        if (existingTrip == null)
        {
            return null;
        }

        existingTrip.VehicleId = trip.VehicleId;
        existingTrip.Date = trip.Date;
        existingTrip.Time = trip.Time;
        existingTrip.DestinationAddress = trip.DestinationAddress;
        existingTrip.MeetingAddress = trip.MeetingAddress;
        existingTrip.Created = trip.Created;
        existingTrip.Modified = trip.Modified;
        existingTrip.CreatedBy = trip.CreatedBy;
        existingTrip.ModifiedBy = trip.ModifiedBy;

        _context.Trips.Update(existingTrip);
        await _context.SaveChangesAsync();
        return existingTrip;
    }

    public async Task<Trip> DeleteTripAsync(int id)
    {
        var trip = await _context.Trips.FindAsync(id);
        if (trip != null)
        {
            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();
        }
        return trip;
    }
}