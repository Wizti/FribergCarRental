using FribergCarRental.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public abstract class User
    {
        [Display(Name = "AnvändarID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Email krävs")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Epostadress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Användarnamn krävs")]
        [Display(Name = "Användarnamn")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lösenord krävs")]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
        public Role? Role { get; set; }
    }
}
