using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email krävs")]
        [Display(Name = "Epostadress")]
        public string Email { get; set; }
    }
}
