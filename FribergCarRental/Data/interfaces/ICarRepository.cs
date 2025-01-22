using FribergCarRental.Models;

namespace FribergCarRental.Data.interfaces
{
    public interface ICarRepository
    {
        Task<Car> GetByIdAsync(int id);
        Task<Car> GetFullByIdAsync(int id);
        Task<List<Car>> GetAllAsync();
        Task RemoveImageAsync(int imageId);
        Task AddAsync(Car car);
        Task UpdateAsync(Car car);
        Task DeleteAsync(int id);
        Task DisableAsync(Car car);
        Task<bool> ExistsAsync(int id);
    }
}
