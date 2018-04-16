using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Name { get; set; }
    }
}
