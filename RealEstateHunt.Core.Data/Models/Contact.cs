using System;
using System.Collections.Generic;

namespace RealEstateHunt.Core.Data
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

        public IEnumerable<ContactCommunication> ContactCommunications { get; set; }
        public IEnumerable<Contract> Contracts { get; set; }
        public IEnumerable<Offer> Offers { get; set; }
    }
}
