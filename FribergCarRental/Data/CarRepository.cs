using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Data
{
    public class CarRepository : ICarRepository
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

        public async Task<List<Car>> GetAllAsync()
        {
            return  await _context.Cars.Include(i => i.Images).ToListAsync();
        }

        public void Add(Car car)
        {
            try
            {
                _context.Cars.Add(car);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }            
        }
    }
}
