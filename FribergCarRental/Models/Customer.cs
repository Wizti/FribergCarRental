using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class Customer : User
    {
        [Required(ErrorMessage = "Förnamn måste anges")]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Efternamn måste anges")]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Telefonnummer måste anges")]
        [Display(Name = "Telefonnummer")]
        public string Phone { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [Display(Name = "Bokningar")]
        public virtual ICollection<Rental>? Rentals { get; set; }
    }
}