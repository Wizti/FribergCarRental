using FribergCarRental.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class CreateCarViewModel
    {
        [Required(ErrorMessage = "Märke är obligatoriskt")]
        [Display(Name = "Märke")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Årsmodell är obligatoriskt")]
        [Display(Name = "Årsmodell")]
        public int Year { get; set; } = 0;
        [Required(ErrorMessage = "Pris per dygn är obligatoriskt")]
        [Display(Name = "Pris per dygn")]
        public int Price { get; set; } = 0;
        [Required(ErrorMessage = "Beskrivning är obligatoriskt")]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        [Required(ErrorMessage = "Bildlänk är obligatoriskt")]
        [Display(Name = "Bildlänk")]
        public string ImageUrl { get; set; }
    }
}
