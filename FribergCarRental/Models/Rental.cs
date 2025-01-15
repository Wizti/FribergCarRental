using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateOnly RentalStart { get; set; }
        public DateOnly RentalEnd { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public Customer Customer { get; set; }
    }
}
