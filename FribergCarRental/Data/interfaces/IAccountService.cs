using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data.interfaces
{
    public interface IAccountService
    {
        Task<User> GetByIdAsync(int id);
        Task<Customer> GetCustomerByEmailAsync(string email);
        Task<Customer> GetCustomerByUsernameAsync(string username);
        Task<User> GetUserByUsernameAsync(string userName);
        Task AddAsync(CreateViewModel createVM);
        Task<bool> CustomerExistsAsync(string email, string username);
    }
}
