using FribergCarRental.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace FribergCarRental.ViewModels
{
    public class RentalViewModel
    {
        public int CarId { get; set; }
        
        public string Model { get; set; }
        
        public int Price { get; set; }
        
        public string Description { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
    }
}
