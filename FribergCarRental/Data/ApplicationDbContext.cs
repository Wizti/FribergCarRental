using Microsoft.EntityFrameworkCore;
using FribergCarRental.Models;
using FribergCarRental.Data.Enums;

namespace FribergCarRental.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("UserType")
                .HasValue<User>("User")
                .HasValue<Admin>("Admin")
                .HasValue<Customer>("Customer");

            modelBuilder.Entity<Admin>().HasData(new Admin
            {
                Id = 1,
                FirstName = "Admin",
                LastName = "User",
                Email = "admin@example.com",
                UserName = "admin",
                Password = "admin",
                Role = Role.Admin
            });

            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Customer)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Rental>()
                .HasOne(r => r.Car)
                .WithMany(c => c.Rentals)
                .HasForeignKey(r => r.CarId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
