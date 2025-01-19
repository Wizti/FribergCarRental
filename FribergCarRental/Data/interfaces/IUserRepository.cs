using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        /*Task<User> GetUserByCustomerIdAsync(string username);
        Task<User> GetByEmailAsync(string email);*/
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByCustomerIdAsync(int CustomerId);
    }
}
