using FribergCarRental.Models;

namespace FribergCarRental.Data.interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetByEmailAsync(string email);
        Task<Customer> GetByUsernameAsync(string username);
        Task<Customer> GetByIdAsync(int id);
    }
}
