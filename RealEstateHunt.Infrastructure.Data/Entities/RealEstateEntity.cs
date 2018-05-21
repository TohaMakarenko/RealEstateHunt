using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data
{
    public class RealEstateEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(250)")]
        public string Name { get; set; }

        [ForeignKey("Type")]
        public int TypeId { get; set; }

        public RealEstateTypeEntity Type { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public CityEntity City { get; set; }

        [ForeignKey("District")]
        public int DistrictId { get; set; }

        public DistrictEntity District { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Street { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Number { get; set; }

        public int Floor { get; set; }

        public int Square { get; set; }

        [Column(TypeName = "varchar(max)")]
        public string Description { get; set; }

        public IEnumerable<OfferEntity> Offers { get; set; }
    }
}
