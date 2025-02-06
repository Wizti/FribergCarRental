using FribergCarRental.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public abstract class User
    {
        [Display(Name = "AnvändarID")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Email måste anges")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Epostadress")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Användarnamn måste anges")]
        [Display(Name = "Användarnamn")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lösenord måste anges")]
        [DataType(DataType.Password)]
        [Display(Name = "Lösenord")]
        public string Password { get; set; }
        public Role? Role { get; set; }
    }
}
