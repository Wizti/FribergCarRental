using FribergCarRental.Models;

namespace FribergCarRental.Data.interfaces
{
    public interface ICarRepository
    {
        Task<Car> GetByIdAsync(int id);
        Task<Car> GetFullByIdAsync(int id);
        Task<List<Car>> GetAllAsync();
        Task AddAsync(Car car);
        void UpdateAsync(Car car);
        void Delete(Car car);
    }
}
