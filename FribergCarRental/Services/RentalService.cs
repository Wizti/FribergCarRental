using FribergCarRental.Data;
using FribergCarRental.Data.interfaces;
using FribergCarRental.Models;

namespace FribergCarRental.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;
        private readonly ICarRepository _carRepository;

        public RentalService(IRentalRepository rentalRepository, ICarRepository carRepository)
        {
            _rentalRepository = rentalRepository;
            _carRepository = carRepository;
        }
        public async Task CreateRentalAsync(Rental rental)
        {
            if (rental.RentalStart >= rental.RentalEnd)
            {
                throw new ArgumentException("Startdatum måste vara tidigare än slutdatum.");
            }

            UpdateRentalStatus(rental);
            await _rentalRepository.AddAsync(rental);
        }

        public async Task<Car> GetCarByIdAsync(int carId)
        {
            return await _carRepository.GetByIdAsync(carId);
        }

        public async Task<bool> IsCarAvailableAsync(int carId, DateOnly startDate, DateOnly endDate)
        {
            var rentals = await _rentalRepository.GetRentalsForCarAsync(carId, startDate, endDate);
            return !rentals.Any();
        }

        public void UpdateRentalStatus(Rental rental)
        {
            var currentDate = DateOnly.FromDateTime(DateTime.Today);

            if (rental.RentalStart > currentDate)
            {
                rental.Status = RentalStatus.Upcoming;
            }
            else if (rental.RentalStart <= currentDate && rental.RentalEnd >= currentDate)
            {
                rental.Status = RentalStatus.Active;
            }
            else
            {
                rental.Status = RentalStatus.Completed;
            }
        }
    }
}
