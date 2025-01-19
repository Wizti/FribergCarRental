using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Användarnamn krävs")]
        public string UserName { get; set; }
        [Required(ErrorMessage ="Email krävs")]
        public string Email { get; set; }
        [ForeignKey("Adress")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

        public virtual ICollection<Rental>? Rentals { get; set; }

    }
}