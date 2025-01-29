using System.ComponentModel.DataAnnotations;

namespace FribergCarRental.ViewModels
{
    public class EditCustomerViewModel
    {
        [Display(Name = "Kundnummer")]
        public int Id { get; set; }
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Display(Name = "Telefonnummer")]
        public string Phone { get; set; }
        [Display(Name = "Gatuadress")]
        public string Street { get; set; }
        [Display(Name = "Postnummer")]
        public int Postalcode { get; set; }
        [Display(Name = "Stad")]
        public string City { get; set; }
        [Display(Name = "Användarnamn")]
        public string UserName { get; set; }
        [Display(Name = "Lösenord")]
        public string? Password { get; set; }
    }
}
