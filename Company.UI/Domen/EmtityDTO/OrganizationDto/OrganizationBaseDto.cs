﻿using Domen.AutoGenerated;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.OrganizationDto
{
    public  class OrganizationBaseDto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

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

        [InverseProperty("Organization")]
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();

        [InverseProperty("Organization")]
        public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
    }
}
