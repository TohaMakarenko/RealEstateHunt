using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure
{
    public class OfferEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [ForeignKey("RealEstate")]
        public int RealEstateId { get; set; }

        public RealEstateEntity RealEstate { get; set; }

        [ForeignKey("Manager")]
        public int ManagerId { get; set; }

        public EmployeeEntity Manager { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        public int Price { get; set; }

        public IEnumerable<ContractEntity> Contracts { get; set; }
    }
}
