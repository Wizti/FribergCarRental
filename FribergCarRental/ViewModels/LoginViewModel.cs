using FribergCarRental.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Användarnamn eller email måste anges")]
        [Display(Name = "Användarnamn")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Lösenord måste anges")]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
    }
}
