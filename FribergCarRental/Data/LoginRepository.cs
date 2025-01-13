using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public class LoginRepository : ILogin
    {
        private readonly ApplicationDbContext _context;

        public LoginRepository(ApplicationDbContext context)
        {
            this._context = context;
        }
        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }
}
