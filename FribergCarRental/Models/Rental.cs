using FribergCarRental.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class Rental
    {
        [Display(Name = "Bokningsnummer")]
        public int Id { get; set; }
        [Display(Name = "Status")]
        public RentalStatus Status { get; set; }
        [Display(Name = "Startdatum")]
        public DateOnly RentalStart { get; set; }
        [Display(Name = "Slutdatum")]
        public DateOnly RentalEnd { get; set; }
        [Display(Name = "Kundnummer")]
        public int? CustomerId { get; set; }        
        public Customer? Customer { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        
        
    }
}
