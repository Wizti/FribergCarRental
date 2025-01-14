using FribergCarRental.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Användarnamn eller email krävs")]
        public string Login { get; set; }
        [Required(ErrorMessage = "Lösenord krävs")]
        public string Password { get; set; }
        //public bool RememberMe { get; set; }
    }
}
