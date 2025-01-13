﻿namespace FribergCarRental.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<Adress> Adresses { get; set; }

    }
}