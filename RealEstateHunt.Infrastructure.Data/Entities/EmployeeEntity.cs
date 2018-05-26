using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data.Entities
{
    [Table("Employee")]
    public class EmployeeEntity
    {
        public int Id { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public ContactEntity Contact { get; set; }

        public ICollection<ContractEntity> Contracts { get; set; }
    }
}
