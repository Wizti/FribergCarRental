using FribergCarRental.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class CreateCarViewModel
    {
        [Display(Name = "Märke")]
        public string Model { get; set; }
        [Display(Name = "Årsmodell")]
        public int Year { get; set; }
        [Display(Name = "Pris per dygn")]
        public int Price { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        public bool? IsActive { get; set; }
        [Display(Name = "Bildlänk")]
        public string ImageUrl { get; set; }
    }
}
