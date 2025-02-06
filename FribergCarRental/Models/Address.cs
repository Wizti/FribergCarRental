using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Gata måste anges")]
        [Display(Name = "Gata")]
        public string Street { get; set; }
        [Required(ErrorMessage = "Postnummer måste anges")]
        [Display(Name = "Postnummer")]
        public int Postalcode { get; set; }
        [Required(ErrorMessage = "Stad måste anges")]
        [Display(Name = "Stad")]
        public string City { get; set; }
    }
}