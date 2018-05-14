using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    public class City
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }

        public IEnumerable<District> Districts { get; set; }
        public IEnumerable<Contact> Contacts { get; set; }
        public IEnumerable<RealEstate> RealEstates { get; set; }
    }
}
