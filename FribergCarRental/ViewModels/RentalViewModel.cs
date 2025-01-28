using FribergCarRental.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class RentalViewModel
    {
        public Car Car { get; set; }
        [Display(Name = "Startdatum")]
        public DateOnly StartDate { get; set; }
        [Display(Name = "Slutdatum")]
        public DateOnly EndDate { get; set; }
    }
}
