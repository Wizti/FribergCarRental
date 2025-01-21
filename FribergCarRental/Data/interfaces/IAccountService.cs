using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data.interfaces
{
    public interface IAccountService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByEmailOrUsernameAsync(string login, bool isEmail);        
        Task<User> GetUserByUsernameAsync(string userName);
        Task<User> GetUserByEmailAsync(string email);
        Task AddAsync(Customer customer);
        Task<bool> UserExistsAsync(string email, string username);
    }
}
