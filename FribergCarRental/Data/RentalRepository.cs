using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Data
{
    public class RentalRepository : IRental
    {
        private readonly ApplicationDbContext _context;
        public RentalRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Car> GetByIdAsync(int carId)
        {
            return await _context.Cars.FirstOrDefaultAsync(c => c.Id == carId);
        }

        public async Task AddAsync(Rental rental)
        {
            await _context.Rentals.AddAsync(rental);
            await _context.SaveChangesAsync();
        }
    }
}
