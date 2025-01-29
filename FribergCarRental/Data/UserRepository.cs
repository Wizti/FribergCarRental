using FribergCarRental.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
        public async Task<Customer> GetCustomerByIdAsync(int userId)
        {
            return await _context.Users.OfType<Customer>().Include(a => a.Address).FirstOrDefaultAsync(c => c.Id == userId);
        }

        public async Task<Customer> GetAllRentalsByCustomerAsync(int userId)
        {
            return await _context.Users.OfType<Customer>().Include(r => r.Rentals).FirstOrDefaultAsync(i => i.Id == userId);
        }

        public async Task<Admin> GetAdminByIdAsync(int userId)
        {
            return await _context.Users.OfType<Admin>().FirstOrDefaultAsync(a => a.Id == userId);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Users.OfType<Customer>().ToListAsync();
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Email == email);

        }

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(User user)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }


    }
}
