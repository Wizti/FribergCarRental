using FribergCarRental.Data;
using FribergCarRental.Data.Enums;
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
            UpdateRentalStatus(rental);
            await _rentalRepository.AddAsync(rental);
        }

        public async Task<Rental> GetRentalAsync(int rentalId)
        {
            return await _rentalRepository.GetFullRentalByIdAsync(rentalId);
        }

        public async Task<Car> GetCarByIdAsync(int carId)
        {
            return await _carRepository.GetByIdAsync(carId);
        }

        public async Task<bool> IsCarAvailableAsync(int carId, DateOnly startDate, DateOnly endDate)
        {
            var rentals = await _rentalRepository.GetOverlappingRentalsForCarAsync(carId, startDate, endDate);
            return !rentals.Any();
        }

        public async Task<List<Car>> GetAllAvailableCarsAsync(DateOnly startDate, DateOnly endDate)
        {
            var cars = await _carRepository.GetAllAsync();
            var availableCars = new List<Car>();

            foreach (var car in cars)
            {
                var rentals = await _rentalRepository.GetOverlappingRentalsForCarAsync(car.Id, startDate, endDate);
                if(!rentals.Any())
                {
                    if (car.IsActive == true)
                    {
                        availableCars.Add(car);
                    }
                }
            }

            return availableCars;
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

        public async Task<decimal> CalculateTotalPriceAsync(DateOnly startDate, DateOnly endDate, int carId)
        {
            var car = await GetCarByIdAsync(carId);
            var totalDays = (endDate.ToDateTime(new TimeOnly()) - startDate.ToDateTime(new TimeOnly())).Days;

            return totalDays * car.Price;
        }

        public async Task<List<Rental>> GetAllRentalAsync()
        {
            var rentals = await _rentalRepository.GetAllRentalsAsync();

            foreach (var rental in rentals)
            {
                UpdateRentalStatus(rental);
            }
            return rentals;
        }

        public async Task<Rental> GetFullRentalAsync(int rentalId)
        {
            return await _rentalRepository.GetFullRentalByIdAsync(rentalId);
        }
    }
}
