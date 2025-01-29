using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Gata")]
        public string Street { get; set; }
        [Required]
        [Display(Name = "Postnummer")]
        public int Postalcode { get; set; }
        [Required]
        [Display(Name = "Stad")]
        public string City { get; set; }
    }
}