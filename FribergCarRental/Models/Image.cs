using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageUrl { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
    }
}
