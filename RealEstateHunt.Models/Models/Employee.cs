using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [ForeignKey("Contact")]
        public int ContactId { get; set; }

        public Contact Contact { get; set; }

        public IEnumerable<Contract> Contracts { get; set; }
    }
}
