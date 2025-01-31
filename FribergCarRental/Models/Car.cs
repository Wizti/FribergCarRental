using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.Models
{
    public class Car
    {
        [Display(Name = "BilID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Märke")]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Årsmodell")]
        public int Year { get; set; }   
        [Required]
        [Display(Name = "Pris per dygn")]
        public int Price { get; set; }
        [Required]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [Display(Name = "Status")]
        public bool? IsActive { get; set; }
        [Display(Name = "Bilder")]
        public virtual List<Image>? Images { get; set; }
        [Display(Name = "Bokningar")]
        public virtual ICollection<Rental>? Rentals { get; set; }
    }
}
