using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data;

public class ManifestService
{
    private readonly ApplicationDbContext _context;

    public ManifestService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<List<Manifest>> GetManifestsAsync()
    {
        return await _context.Manifests.ToListAsync();
    }

    public async Task<Manifest> GetManifestAsync(int manifestId, string memberId)
    {
        return await _context.Manifests.FindAsync(manifestId, memberId);
    }

    public async Task<Manifest> AddManifestAsync(Manifest manifest)
    {
        _context.Manifests.Add(manifest);
        await _context.SaveChangesAsync();
        return manifest;
    }

    public async Task<Manifest> UpdateManifestAsync(int manifestId, string memberId, Manifest manifest)
    {
        var existingManifest = await _context.Manifests.FindAsync(manifestId, memberId);

        if(existingManifest == null)
        {
            return null;
        }

        existingManifest.MemberId = manifest.MemberId;
        existingManifest.TripId = manifest.TripId;
        existingManifest.VehicleId = manifest.VehicleId;
        existingManifest.Notes = manifest.Notes;
        existingManifest.Created = manifest.Created;
        existingManifest.Modified = manifest.Modified;
        existingManifest.CreatedBy = manifest.CreatedBy;
        existingManifest.ModifiedBy = manifest.ModifiedBy;

        _context.Manifests.Update(existingManifest);
        await _context.SaveChangesAsync();
        return existingManifest;
    }

     public async Task<Manifest> DeleteManifestAsync(int manifestId, string memberId)
     {
          var manifest = _context.Manifests.FirstOrDefault(x => x.ManifestId == manifestId && x.MemberId == memberId);
          _context.Manifests.Remove(manifest);
          await _context.SaveChangesAsync();
          return manifest;
     }
}