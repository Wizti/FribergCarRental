using FribergCarRental.Models;

namespace FribergCarRental.Data.interfaces
{
    public interface IRentalService
    {
        Task<Car> GetCarByIdAsync(int carId);
        Task CreateRentalAsync(Rental rental);
        void UpdateRentalStatus(Rental rental);
        Task<bool> IsCarAvailableAsync(int carId, DateOnly startDate, DateOnly endDate);
        Task<List<Rental>> GetAllRentalAsync();
        Task<decimal> CalculateTotalPriceAsync(DateOnly startDate, DateOnly endDate, int carId);
        Task<Rental> GetFullRentalAsync(int rentalId);        
    }
}
