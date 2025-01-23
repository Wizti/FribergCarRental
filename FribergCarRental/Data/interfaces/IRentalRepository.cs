using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data
{
    public interface IRentalRepository
    {
        Task AddAsync(Rental rental);
        Task<List<Rental>> GetOverlappingRentalsForCarAsync(int carId, DateOnly startDate, DateOnly endDate);
        Task<List<Rental>> GetAllRentalsAsync();
        Task<Rental> GetFullRentalByIdAsync(int rentalId);
        Task<Rental> GetByIdAsync(int rentalId);
        Task DeleteAsync(Rental rental);
    }
}
