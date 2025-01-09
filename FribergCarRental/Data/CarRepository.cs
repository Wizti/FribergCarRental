using FribergCarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context)
        {
            this._context = context;
        }


        public async Task<Car> GetByIdAsync(int id)
        {
            return await _context.Cars.FindAsync(id);
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }
    }
}
