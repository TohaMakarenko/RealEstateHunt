using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data.Entities
{
    public class UserEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }


        [Column(TypeName = "varchar(256)")]
        public string Email { get; set; }

        [Column(TypeName = "varchar(30)")]
        public string Phone { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public ContactEntity Contact { get; set; }
    }
}
