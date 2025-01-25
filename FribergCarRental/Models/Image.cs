using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FribergCarRental.Models
{
    public class Image
    {
        public int Id { get; set; }
        [Display(Name = "Bild-länk")]
        public string? ImageUrl { get; set; }
        [ForeignKey("Car")]
        public int CarId { get; set; }
    }
}
