using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public interface ICustomer
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> GetByIdAsync(int id);
    }
}
