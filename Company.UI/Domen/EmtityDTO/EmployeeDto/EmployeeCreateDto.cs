﻿namespace Domen.EmtityDTO.EmployeeDto
{
    public class EmployeeCreateDto : EmployeeBeseDto
    {
        public int UserId { get; set; }
        public string EmployeeName { get; set; } = null!;
        public int? EmployeeLevel { get; set; }
        public int? OrganizationId { get; set; }
        public string Email { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public int? Departmentid { get; set; }
        public decimal Salary { get; set; }
        public bool Isactive { get; set; }
    }
}
