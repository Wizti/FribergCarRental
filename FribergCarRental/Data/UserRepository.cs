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

        /*public async Task<User> GetByEmailAsync(string email)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(e => e.Email == email);
            return await _context.Users.FirstOrDefaultAsync(i => i.CustomerId == customer.Id);
        }*/

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

       /* public async Task<User> GetUserByCustomerIdAsync(int customerId)
        {            
            //return await _context.Users.FirstOrDefaultAsync(u => u.CustomerId == customerId);

            // OBS TILLFÄLLIG LÖSNING!!!!
            return await GetByIdAsync(customerId);
        }*/
        public async Task<User> GetByEmailAsync(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(c => c.Email == email);

        }

       /* public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }*/

        public async Task<User> GetByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
