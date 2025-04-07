// Data/ApplicationDbContext.cs
using System.Collections.Generic;
using System.Reflection.Emit;
using EventEase.Models;
using Microsoft.EntityFrameworkCore;

namespace EventEase.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Venue> Venues { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure unique constraint for preventing double bookings
            modelBuilder.Entity<Booking>()
                .HasIndex(b => new { b.VenueId, b.StartTime, b.EndTime })
                .IsUnique();

            // Configure ON DELETE RESTRICT for Venue and Event in Booking
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Venue)
                .WithMany(v => v.Bookings)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Bookings)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}