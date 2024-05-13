namespace Domen.EmtityDTO.EmployeeDto
{
    public class EmployeeBeseDto
    {
        public string EmployeeName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public decimal Salary { get; set; }
        public bool Isactive { get; set; }
    }
}
