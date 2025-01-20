using FribergCarRental.Data;
using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;
using FribergCarRental.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FribergCarRental.Services
{
    public class AccountService : IAccountService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

        public AccountService(ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            _customerRepository = customerRepository;
            _userRepository = userRepository;
        }
        public async Task AddAsync(Customer customer)
        {
            await _customerRepository.AddAsync(customer);
            //customer.User.CustomerId = customer.Customer.Id;
            //await _userRepository.AddAsync(customer.User);
        }

        public async Task<bool> UserExistsAsync(string email, string username)
        {
            bool emailExists = await _userRepository.GetByEmailAsync(email) != null;
            bool userNameExits = await _userRepository.GetByUsernameAsync(username) != null;

            return emailExists || userNameExits;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userRepository.GetByEmailAsync(email);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetByUsernameAsync(username);
        }
    }
}
