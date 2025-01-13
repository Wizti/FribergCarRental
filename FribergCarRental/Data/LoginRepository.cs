using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Data
{
    public class LoginRepository : ILogin
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public void AddAsync(LoginViewModel modelVM)
        {
            _context.Users.Add(modelVM.User);
            _context.Customers.Add(modelVM.Customer);
            _context.SaveChanges();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<Customer> GetUserByEmailAsync(string email)
        {
            return await _context.Customers.FirstOrDefaultAsync(e => e.Email == email);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        Task<User> ILogin.GetUserByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }
    }
}
