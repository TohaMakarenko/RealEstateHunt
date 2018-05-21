﻿using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Infrastructure.Data
{
    public class RealEstateTypeEntity
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(50)")]
        public int Name { get; set; }
    }
}
