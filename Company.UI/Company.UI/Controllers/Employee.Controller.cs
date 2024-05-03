using Aplication.Services;
using Domen.EmtityDTO.EmployeeDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class Employee : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public Employee(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeGetDto>> CreateEmployee(EmployeeCreateDto employeeDto)
        {
            var employee = await _employeeService.CreateEmployeeAsync(employeeDto);
            return CreatedAtAction(nameof(GetByIdEmployee), new { id = employee.UserId }, employee);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeGetDto>> GetByIdEmployee(int id)
        {
            var employee = await _employeeService.GetByIdEmployeeAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

       /* [HttpGet]
        public async Task<ActionResult<List<EmployeeGetDto>>> GetAllEmployees()
        {
            var employees = await _employeeService.GetAllEmployeesAsync();
            return Ok(employees);
        }*/

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, EmployeeUpdateDto employeeDto)
        {
            if (id != employeeDto.UserId)
                return BadRequest("Employee ID mismatch");

            await _employeeService.UpdateEmployeeAsync(employeeDto);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var success = await _employeeService.DeleteEmployeeAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }   

    }
}
