using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public interface ICar
    {
        Task<Car> GetByIdAsync(int id);
        Task<IEnumerable<Car>> GetAllAsync();
    }
}
