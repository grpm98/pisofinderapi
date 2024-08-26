using Microsoft.EntityFrameworkCore;
using pisofinderapi.Models;

namespace pisofinderapi.Data;
public class PisoFinderContext : DbContext
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<PropertyImage> PropertyImages { get; set; }
    public DbSet<Agent> Agents { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<PropertyType> PropertyTypes { get; set; }

    // Constructor that calls the base class constructor
    public PisoFinderContext(DbContextOptions<PisoFinderContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Property-Address One-to-One Relationship
        modelBuilder.Entity<Property>()
            .HasOne(p => p.Address);

        // Property-PropertyType Many-to-One Relationship
        modelBuilder.Entity<Property>()
            .HasOne(p => p.PropertyType)
            .WithMany(pt => pt.Properties)
            .HasForeignKey(p => p.PropertyTypeId);

        // Property-Agent Many-to-One Relationship
        modelBuilder.Entity<Property>()
            .HasOne(p => p.Agent)
            .WithMany(a => a.Properties)
            .HasForeignKey(p => p.AgentId);

        // Property-PropertyImage One-to-Many Relationship
        modelBuilder.Entity<PropertyImage>()
            .HasOne(pi => pi.Property)
            .WithMany(p => p.Images)
            .HasForeignKey(pi => pi.PropertyId);

    }
}
