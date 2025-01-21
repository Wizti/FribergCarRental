using FribergCarRental.Models;

namespace FribergCarRental.ViewModels
{
    public class CreateCarViewModel
    {
        public string Model { get; set; }
        public int Year { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        public string ImageUrl { get; set; }
    }
}
