using FribergCarRental.Data;
using FribergCarRental.Data.interfaces;

namespace FribergCarRental.Services
{
    public class AdminService : IAdminService
    {
        private readonly IRentalService _rentalService;

        public AdminService(IRentalService rentalService)
        {
            this._rentalService = rentalService;
        }
    }
}
