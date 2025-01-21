using FribergCarRental.Data;
using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Services
{
    public class AccountService : IAccountService
    {
        private readonly IUserRepository _userRepository;

        public AccountService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task AddAsync(Customer customer)
        {
            await _userRepository.AddAsync(customer);
        }

        public async Task<bool> UserExistsAsync(string email, string username)
        {
            bool emailExists = await _userRepository.GetByEmailAsync(email) != null;
            bool userNameExits = await _userRepository.GetByUsernameAsync(username) != null;

            return emailExists || userNameExits;
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByEmailOrUsernameAsync(string login, bool isEmail)
        {
            if (!isEmail)
            {
                return await _userRepository.GetByUsernameAsync(login);
            }
            else
            {
                return await _userRepository.GetByEmailAsync(login);
            }
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }
    }
}
