using FribergCarRental.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class RentalRecordViewModel
    {
        public Rental Rental { get; set; }
        [Display(Name = "Total summa")]
        public decimal TotalPrice { get; set; }
    }
}
