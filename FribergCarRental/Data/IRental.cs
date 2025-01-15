using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data
{
    public interface IRental
    {
        Task<Car> GetByIdAsync(int carId);
        Task AddAsync(Rental rental);
    }
}
