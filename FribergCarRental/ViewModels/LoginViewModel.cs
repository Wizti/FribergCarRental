using FribergCarRental.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Användarnamn eller email krävs")]
        [Display(Name = "Användarnamn")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Lösenord krävs")]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
    }
}
