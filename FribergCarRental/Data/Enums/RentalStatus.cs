using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.Data.Enums
{
    public enum RentalStatus
    {
        [Display(Name = "Kommande")]

        Upcoming = 1,
        [Display(Name = "Aktiv")]

        Active,
        [Display(Name = "Utförd")]

        Completed
    }
}
