using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data
{
    public class ContactEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }

        public CityEntity City { get; set; }

        [ForeignKey("District")]
        public int? DistrictId { get; set; }

        public DistrictEntity District { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Street { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string BankAccountNumber { get; set; }

        public IEnumerable<ContactCommunicationEntity> ContactCommunications { get; set; }
        public IEnumerable<ContractEntity> Contracts { get; set; }
    }
}
