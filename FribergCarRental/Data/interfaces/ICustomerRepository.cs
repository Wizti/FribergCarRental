using FribergCarRental.Models;

namespace FribergCarRental.Data.interfaces
{
    public interface ICustomerRepository
    {
        Task AddAsync(Customer customer);
        Task<Customer> GetByIdAsync(int id);
    }
}
