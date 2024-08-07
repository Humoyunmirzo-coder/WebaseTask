namespace Domen.EmtityDTO.EmployeeDto
{
    public class EmployeeGetDto : EmployeeBeseDto
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;
        public bool Isactive { get; set; }
    }
}
