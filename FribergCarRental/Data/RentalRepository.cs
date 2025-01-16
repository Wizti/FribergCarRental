using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Data
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ApplicationDbContext _context;
        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }
    }
}
