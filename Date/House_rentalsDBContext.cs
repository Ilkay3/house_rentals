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
                    new MySqlServerVersion(new Version(8, 0, 41)));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<House_Amenity>()
                .HasKey(ha => new { ha.HouseId, ha.AmenityId });

            modelBuilder.Entity<House_Amenity>()
                .HasOne(ha => ha.Amenity)
                .WithMany(a => a.House_Amenities)
                .HasForeignKey(ha => ha.AmenityId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
