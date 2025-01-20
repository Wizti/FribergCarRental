using Microsoft.EntityFrameworkCore;
using FribergCarRental.Models;

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
    }
}
