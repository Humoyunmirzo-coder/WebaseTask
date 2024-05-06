using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.EmployeeDto
{
    public  class EmployeeCreateDto : EmployeeBeseDto
    {
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public decimal Salary { get; set; }

        public bool Isactive { get; set; }
    }
}
