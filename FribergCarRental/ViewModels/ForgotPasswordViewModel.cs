using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email måste anges")]
        [Display(Name = "Epostadress")]
        public string Email { get; set; }
    }
}
