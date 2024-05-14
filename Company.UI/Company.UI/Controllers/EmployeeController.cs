using Aplication.Services.EmployeeServices;
using Domen.EmtityDTO.EmployeeDto;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers;

[Route("[controller]/[action]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        List<EmployeeGetDto> employees = await _employeeService.GetAllEmployeesAsync();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdEmployee(int id)
    {
        var employee = await _employeeService.GetByIdEmployeeAsync(id);
        return Ok(employee);
    }

    [HttpPost]
    public async Task<EmployeeGetDto> CreateEmployee(EmployeeCreateDto employeeCreateDto)
    {
        var employe = await _employeeService.CreateEmployeeAsync(employeeCreateDto);
        return employe;
    }

    [HttpPut]
    public async Task<ActionResult<EmployeeGetDto>> UpdateEmployee([FromBody] EmployeeUpdateDto employeeUpdate)
    {
        try
        {
            if (employeeUpdate == null)
            {
                return BadRequest("employee data must be provided.");
            }
            var updatedUser = await _employeeService.UpdateEmployeeAsync(employeeUpdate);
            if (updatedUser == null)
            {
                return NotFound($"employee with ID {employeeUpdate.Id} not found.");
            }
            return Ok(updatedUser);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }



    [HttpDelete]
    public async Task<bool> DeleteEmoployee(int Id)
    {
        if (Id != 0)
        {
            return await _employeeService.DeleteEmployeeAsync(Id);
        }
        return false;
    }


}
