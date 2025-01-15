using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email krävs")]
        public string Email { get; set; }
    }
}
