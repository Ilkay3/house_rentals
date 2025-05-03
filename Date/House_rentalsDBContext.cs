using house_rentals.Date.Models;
using Microsoft.EntityFrameworkCore;

namespace house_rentals.Date
{
    public class HouseRentalsDBContext : DbContext
    {
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<House_Amenity> House_Amenities { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        public HouseRentalsDBContext()
        {
        }

        public HouseRentalsDBContext(DbContextOptions<HouseRentalsDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=House_Rentals;User=root;Password=21012007;",
                    new MySqlServerVersion(new Version(8, 0, 41))); // Adjust based on your MySQL version
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House_Amenity>()
                .HasKey(ha => new { ha.HouseId, ha.AmenityId });

            //modelBuilder.Entity<House_Amenity>()
            //    .HasOne(ha => ha.House)
            //    .WithMany(h => h.House_Amenities)
            //    .HasForeignKey(ha => ha.HouseId)
            //    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<House_Amenity>()
                .HasOne(ha => ha.Amenity)
                .WithMany(a => a.House_Amenities)
                .HasForeignKey(ha => ha.AmenityId)
                .OnDelete(DeleteBehavior.Cascade);

            /*modelBuilder.Entity<Booking>()
                .HasOne(b => b.House)
                .WithMany()
                .HasForeignKey(b => b.HouseId);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Tenant)
                .WithMany()
                .HasForeignKey(b => b.TenantId);

            modelBuilder.Entity<House>()
                .HasOne(h => h.City)
                .WithMany()
                .HasForeignKey(h => h.CityId);

            modelBuilder.Entity<House>()
                .HasOne(h => h.Owner)
                .WithMany()
                .HasForeignKey(h => h.OwnerId);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.Booking)
                .WithMany()
                .HasForeignKey(p => p.BookingId);

            modelBuilder.Entity<Tenant>()
                .HasKey(t => t.OwnerId);*/
        }
    }
}
