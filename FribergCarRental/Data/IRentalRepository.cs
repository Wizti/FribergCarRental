using FribergCarRental.Models;
using FribergCarRental.ViewModels;

namespace FribergCarRental.Data
{
    public interface IRentalRepository
    {
        Task AddAsync(Rental rental);
    }
}
