using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public interface ICarRepository
    {
        Task<Car> GetByIdAsync(int id);
        Task<List<Car>> GetAllAsync();
    }
}
