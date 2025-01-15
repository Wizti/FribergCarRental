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
        [Required(ErrorMessage ="Behöver email")]
        public string Email { get; set; }
        [ForeignKey("Adress")]
        public int AddressId { get; set; }
        public Address Address { get; set; }

    }
}