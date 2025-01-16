using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data
{
    public class AccountService : IAccountService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUserRepository _userRepository;

        public AccountService(ICustomerRepository customerRepository, IUserRepository userRepository)
        {
            this._customerRepository = customerRepository;
            this._userRepository = userRepository;
        }
        public async Task AddAsync(CreateViewModel createVM)
        {
            await _customerRepository.AddAsync(createVM.Customer);
            createVM.User.CustomerId = createVM.Customer.Id;
            await _userRepository.AddAsync(createVM.User);
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
