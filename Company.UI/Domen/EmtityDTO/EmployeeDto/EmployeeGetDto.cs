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
        public string Email { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public bool Isactive { get; set; }
    }
}
