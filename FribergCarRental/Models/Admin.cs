using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.Models
{
    public class Admin : User
    {
        public int Id { get; set; }
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
    }
}
