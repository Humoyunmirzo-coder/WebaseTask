using Aplication.Services;
using Domen.EmtityDTO.EmployeeDto;
using Domen.EmtityDTO.UserDto;
using Infrastructure.Servises;
using Microsoft.AspNetCore.Http;
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
    public async Task<ActionResult<EmployeeGetDto>> UpdateEmployee([FromBody] EmployeeUpdateDto  employeeUpdateDto)
    {
        try
        {
            if (employeeUpdateDto == null)
            {
                return BadRequest("Employee data must be provided.");
            }
            var updatedEmp = await _employeeService.UpdateEmployeeAsync(employeeUpdateDto);
            if (updatedEmp == null)
            {
                return NotFound($"Employee with ID {employeeUpdateDto.Id} not found.");
            }
            return Ok(updatedEmp);
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
