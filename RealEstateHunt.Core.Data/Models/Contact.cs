using System;
using System.Collections.Generic;

namespace RealEstateHunt.Core.Data.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public City City { get; set; }
        public District District { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public DateTime BirthDate { get; set; }
        public string BankAccountNumber { get; set; }
        public RealEstateType PreferredType { get; set; }
        public int PreferredPrice { get; set; }
        
        public IEnumerable<Offer> Offers { get; set; }
    }
}
