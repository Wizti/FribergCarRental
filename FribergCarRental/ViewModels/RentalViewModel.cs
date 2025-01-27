using FribergCarRental.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class RentalViewModel
    {
        /*public int CarId { get; set; }
        [Display(Name = "Bil")]
        public string Model { get; set; }
        [Display(Name = "Pris per dygn")]
        public int Price { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }*/
        public Car Car { get; set; }
        [Display(Name = "Startdatum")]
        public DateOnly StartDate { get; set; }
        [Display(Name = "Slutdatum")]
        public DateOnly EndDate { get; set; }
    }
}
