using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.Models
{
    public class Address
    {
        public int Id { get; set; }
        [Display(Name = "Gata")]
        public string Street { get; set; }
        [Display(Name = "Postnummer")]
        public int Postalcode { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
    }
}