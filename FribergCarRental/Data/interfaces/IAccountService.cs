using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data.interfaces
{
    public interface IAccountService
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);        
        Task<User> GetUserByUsernameAsync(string userName);
        Task AddAsync(Customer customer);
        Task<bool> UserExistsAsync(string email, string username);
    }
}
