using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data
{
    public interface ILogin
    {
        public Task<User> GetUserByEmailAsync(string email);
        public Task<User> GetUserByUsernameAsync(string username);
        void AddAsync(CreateViewModel createVM);
    }
}
