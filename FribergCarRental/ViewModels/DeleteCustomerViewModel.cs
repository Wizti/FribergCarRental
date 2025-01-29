using FribergCarRental.Models;

namespace FribergCarRental.ViewModels
{
    public class DeleteCustomerViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int UserId { get; set; }
    }
}
