﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domen.EmtityDTO.OrganizationDto
{
    public class OrganizationBaseDto
    {


        [Column("name")]
        [StringLength(255)]
        public string Name { get; set; } = null!;

        [Column("address")]
        [StringLength(255)]
        public string Address { get; set; } = null!;

        [Column("phone_number")]
        [StringLength(255)]
        public string PhoneNumber { get; set; } = null!;

        [Column("email")]
        [StringLength(255)]
        public string Email { get; set; } = null!;


    }
}
