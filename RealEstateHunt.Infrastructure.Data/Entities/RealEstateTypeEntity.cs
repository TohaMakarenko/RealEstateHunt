﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data.Entities
{
    [Table("RealEstateType")]
    public class RealEstateTypeEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Name { get; set; }
    }
}
