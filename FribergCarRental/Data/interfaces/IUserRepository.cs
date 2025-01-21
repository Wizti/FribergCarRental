using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public interface IUserRepository
    {
        Task AddAsync(User user);
        Task<User> GetByIdAsync(int id);
        Task<Customer> GetCustomerByIdAsync(int userId);
        Task<Admin> GetAdminByIdAsync(int userId);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int userId);
        Task<IEnumerable<User>> GetAllAsync();
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<User> GetByEmailAsync(string email);
        Task<User> GetByUsernameAsync(string userName);
        
    }
}
