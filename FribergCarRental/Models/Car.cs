using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.Models
{
    public class Car
    {
        [Display(Name = "BilID")]
        public int Id { get; set; }
        [Display(Name = "Märke")]
        public string Model { get; set; }
        [Display(Name = "Årsmodell")]
        public int Year { get; set; }
        [Display(Name = "Pris per dygn")]
        public int Price { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        [Display(Name = "Aktiv")]
        public bool? IsActive { get; set; }
        [Display(Name = "Bilder")]
        public virtual List<Image>? Images { get; set; }
        [Display(Name = "Bokningar")]
        public virtual ICollection<Rental>? Rentals { get; set; }
    }
}
