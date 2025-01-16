using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data
{
    public interface IAccountService
    {
        Task<User> GetByIdAsync(int id);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByUsernameAsync(string username);
        Task AddAsync(CreateViewModel createVM);
    }
}
