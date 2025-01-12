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

        public Task<List<Car>> GetAllAsync()
        {
            return  _context.Cars.Include(i => i.Images).ToListAsync();
        }
    }
}
