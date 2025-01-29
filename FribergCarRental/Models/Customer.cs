using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class Customer : User
    {
        [Required]
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Required]
        [Display(Name = "Telefonnummer")]
        public string Phone { get; set; }
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [Display(Name = "Bokningar")]
        public virtual ICollection<Rental>? Rentals { get; set; }
    }
}