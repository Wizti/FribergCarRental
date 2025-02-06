using FribergCarRental.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class CreateCarViewModel
    {
        [Required(ErrorMessage = "Märke måste anges")]
        [Display(Name = "Märke")]
        public string Model { get; set; }
        [Required(ErrorMessage = "Årsmodell måste anges")]
        [Display(Name = "Årsmodell")]
        public int Year { get; set; } = 0;
        [Required(ErrorMessage = "Pris per dygn måste anges")]
        [Display(Name = "Pris per dygn")]
        public int Price { get; set; } = 0;
        [Required(ErrorMessage = "Beskrivning måste anges")]
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        [Required(ErrorMessage = "Bildlänk måste anges")]
        [Display(Name = "Bildlänk")]
        public string ImageUrl { get; set; }
    }
}
