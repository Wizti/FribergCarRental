using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public interface IUser
    {
        Task AddAsync(User user);
        Task<User> GetByUsernameAsync(string username);
        Task<User> GetByEmailAsync(string email);
    }
}
