using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data.Entities
{
    [Table("District")]
    public class DistrictEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }

        public CityEntity City { get; set; }

        public ICollection<ContactEntity> Contacts { get; set; }
        public ICollection<RealEstateEntity> RealEstates { get; set; }
    }
}
