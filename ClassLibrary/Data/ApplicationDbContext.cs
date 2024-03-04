using ClassLibrary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Data;

public class ApplicationDbContext : IdentityDbContext<Member, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Member> Members { get; set; }

    public DbSet<Vehicle> Vehicles { get; set; }

    public DbSet<Trip> Trips { get; set; } 

    public DbSet<Manifest> Manifests { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Vehicle>().ToTable("Vehicle");

        builder.Entity<Trip>()
            .HasKey(t => new { t.TripId, t.VehicleId });
        builder.Entity<Trip>().ToTable("Trip");
        
        builder.Entity<Manifest>()
            .HasKey(e => new { e.ManifestId, e.MemberId });
        builder.Entity<Manifest>()
            .HasOne(m => m.Trip)
            .WithOne()
            .HasForeignKey<Manifest>(m => new { m.TripId, m.VehicleId });
        builder.Entity<Manifest>().ToTable("Manifest");

        builder.Seed();
    }
}
