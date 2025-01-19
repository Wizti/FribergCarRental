using FribergCarRental.Models;

namespace FribergCarRental.Data.interfaces
{
    public interface ICarRepository
    {
        Task<Car> GetByIdAsync(int id);
        Task<List<Car>> GetAllAsync();
    }
}
