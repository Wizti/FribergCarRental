using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public class CustomerRepository : ICustomer
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

        public Task<Customer> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<Customer> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
