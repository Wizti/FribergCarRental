using FribergCarRental.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public abstract class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Email krävs")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Användarnamn krävs")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lösenord krävs")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public Role? Role { get; set; }
    }
}
