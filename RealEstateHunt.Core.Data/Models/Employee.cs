using System.Collections.Generic;

namespace RealEstateHunt.Core.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public Contact Contact { get; set; }

        public IEnumerable<Contract> Contracts { get; set; }
    }
}
