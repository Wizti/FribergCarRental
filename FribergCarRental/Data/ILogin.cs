using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public interface ILogin
    {
        Task<User> GetByIdAsync(int id);
    }
}
