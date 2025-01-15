using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Användarnamn eller email krävs")]
        public string User { get; set; }
    }
}
