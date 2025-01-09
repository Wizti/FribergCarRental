using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class User
    {
        public int Id { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public bool IsAdmin { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
