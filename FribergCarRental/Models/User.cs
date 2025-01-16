using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class User
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }        
        public bool IsAdmin { get; set; }
        
        [Required(ErrorMessage = "Lösenord krävs")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
