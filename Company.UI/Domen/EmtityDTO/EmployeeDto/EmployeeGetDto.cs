using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domen.EmtityDTO.EmployeeDto
{
    public class EmployeeGetDto : EmployeeBeseDto
    {
        public int UserId { get; set; }

        public string EmployeeName { get; set; } = null!;

        public int? EmployeeLevel { get; set; }

        public int? OrganizationId { get; set; }

        [StringLength(255)]
        public string Email { get; set; } = null!;

        [StringLength(255)]
        public string Phonenumber { get; set; } = null!;

        public DateOnly Hiredate { get; set; }

        public int? Departmentid { get; set; }

        public decimal Salary { get; set; }

        public bool Isactive { get; set; }
    }
}
