using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Data
{
    public class AccountRepository : IAccount
    {
        private readonly ApplicationDbContext _context;

        public AccountRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void Add(CreateViewModel createVM)
        {
            _context.Customers.Add(createVM.Customer);
            _context.SaveChanges();
            createVM.User.CustomerId = createVM.Customer.Id;
            _context.Users.Add(createVM.User);
            _context.SaveChanges();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(e => e.Email == email);
            return await _context.Users.FirstOrDefaultAsync(i => i.CustomerId == customer.Id);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }
    }
}
