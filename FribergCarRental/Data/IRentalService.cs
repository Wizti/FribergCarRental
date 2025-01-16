using FribergCarRental.Models;

namespace FribergCarRental.Data
{
    public interface IRentalService
    {
        Task<Car> GetCarByIdAsync(int carId);
        Task CreateRentalAsync(Rental rental);
        void UpdateRentalStatus(Rental rental);
    }
}
