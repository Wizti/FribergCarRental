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

        public async Task<Car> GetFullByIdAsync(int id)
        {
            return await _context.Cars.Include(i => i.Images).FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<List<Car>> GetAllAsync()
        {
            return  await _context.Cars.Include(i => i.Images).ToListAsync();
        }

        public async Task AddAsync(Car car)
        {
            try
            {
                await _context.Cars.AddAsync(car);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw;
            }            
        }

        public async void UpdateAsync(Car car)
        {
            _context.Cars.Update(car);
            await _context.SaveChangesAsync();
        }

        public void Delete(Car car)
        {
            _context.Cars.Remove(car);
            _context.SaveChanges();
        }

        
    }
}
