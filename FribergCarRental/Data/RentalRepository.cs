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

        public async Task<List<Rental>> GetAllRentalsAsync()
        {
            return await _context.Rentals.Include(c => c.Car).Include(u => u.Customer).ToListAsync();
        }

        public async Task<List<Rental>> GetOverlappingRentalsForCarAsync(int carId, DateOnly startDate, DateOnly endDate)
        {
            return await _context.Rentals
                .Where(c => c.CarId == carId && ((c.RentalStart <= startDate && c.RentalEnd >= startDate) ||
                (c.RentalStart <= endDate && c.RentalEnd >= endDate) ||
                (c.RentalStart >= startDate && c.RentalEnd <= endDate))).ToListAsync();
        }

        public async Task<Rental> GetFullRentalByIdAsync(int rentalId)
        {
            return await _context.Rentals.Include(c => c.Car).Include(u => u.Customer).FirstOrDefaultAsync(r => r.Id == rentalId);
        }

        public async Task<Rental> GetByIdAsync(int rentalId)
        {
            return await _context.Rentals.FirstOrDefaultAsync(i => i.Id == rentalId);
        }

        public async Task DeleteAsync(Rental rental)
        {
            _context.Rentals.Remove(rental);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Rental>> GetAllCustomerRentalsAsync(int? customerId)
        {
            return await _context.Rentals.Include(c => c.Car).Where(u => u.CustomerId == customerId).ToListAsync();
        }
    }
}
