﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstateHunt.Models
{
    class Contact
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string FirstName { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string LastName { get; set; }

        [ForeignKey("City")]
        public int CityId { get; set; }

        public City City { get; set; }

        [ForeignKey("District")]
        public int DistrictId { get; set; }

        public District District { get; set; }

        [Column(TypeName = "varchar(100)")]
        public string Street { get; set; }

        [Column(TypeName = "varchar(50)")]
        public string Number { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
    }
}
