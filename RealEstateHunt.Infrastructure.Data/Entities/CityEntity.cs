using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data.Entities
{
    [Table("City")]
    public class CityEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public ICollection<DistrictEntity> Districts { get; set; }
        public ICollection<ContactEntity> Contacts { get; set; }
        public ICollection<RealEstateEntity> RealEstates { get; set; }
    }
}
