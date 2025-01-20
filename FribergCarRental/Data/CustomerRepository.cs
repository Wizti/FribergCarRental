using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Data
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task AddAsync(Customer customer)
        {
            await _context.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
