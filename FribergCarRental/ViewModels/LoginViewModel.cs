using FribergCarRental.Models;
using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class LoginViewModel
    {
        public Customer Customer { get; set; }
        public User User { get; set; }
        public string Login { get; set; }
        public bool RememberMe { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(string.IsNullOrWhiteSpace(User.UserName) || string.IsNullOrWhiteSpace(User.PassWord))
            {
                yield return new ValidationResult("Användarnamn eller email och lösenord krävs");
            }
        }
    }
}
