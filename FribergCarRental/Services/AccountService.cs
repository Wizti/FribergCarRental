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
        public async Task AddAsync(CreateViewModel createVM)
        {
            await _customerRepository.AddAsync(createVM.Customer);
            createVM.User.CustomerId = createVM.Customer.Id;
            createVM.User.IsAdmin = false;
            await _userRepository.AddAsync(createVM.User);
        }

        public async Task<bool> CustomerExistsAsync(string email, string username)
        {
            bool emailExists = await _customerRepository.GetByEmailAsync(email) != null;
            bool userNameExits = await _customerRepository.GetByUsernameAsync(username) != null;
            return emailExists || userNameExits;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _userRepository.GetByIdAsync(id);
        }

        public async Task<Customer> GetCustomerByEmailAsync(string email)
        {
            return await _customerRepository.GetByEmailAsync(email);
        }

        public async Task<Customer> GetCustomerByUsernameAsync(string username)
        {
            return await _customerRepository.GetByUsernameAsync(username);
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var customer = await GetCustomerByUsernameAsync(username);
            return await _userRepository.GetUserByCustomerIdAsync(customer.Id);
        }
    }
}
