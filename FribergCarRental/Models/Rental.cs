using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateOnly RentalStart { get; set; }
        public DateTime RentalEnd { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
    }
}
