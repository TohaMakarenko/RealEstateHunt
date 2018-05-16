using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure
{
    public class CityEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public IEnumerable<DistrictEntity> Districts { get; set; }
        public IEnumerable<ContactEntity> Contacts { get; set; }
        public IEnumerable<RealEstateEntity> RealEstates { get; set; }
    }
}
