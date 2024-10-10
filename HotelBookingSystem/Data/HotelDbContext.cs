using Microsoft.EntityFrameworkCore;
using HotelBookingSystem.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace HotelBookingSystem.Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options) { }

        // Define DbSet properties for the models
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Customer> Customers { get; set; }

        // Seeding the database with initial data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed initial hotel and room data for testing
            modelBuilder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id = 1,
                    Name = "Sunrise Hotel",
                    Location = "New York"
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Ocean View Resort",
                    Location = "California"
                });

            modelBuilder.Entity<Room>().HasData(
                new Room("Single")
                {
                    Id = 1,
                    IsAvailable = true,
                    HotelId = 1
                },
                new Room("Double")
                {
                    Id = 2,
                    IsAvailable = true,
                    HotelId = 1
                },
                new Room("Suite")
                {
                    Id = 3,
                    IsAvailable = true,
                    HotelId = 2
                });
        }
    }
}
