using Aplication.Services;
using Domen.EmtityDTO.EmployeeDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    [HttpGet]
    public async Task<IActionResult> GetEmployees()
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
    public async Task<IActionResult> CreateEmployee(EmployeeCreateDto employeeCreateDto)
    {
        var employe = await _employeeService.CreateEmployeeAsync(employeeCreateDto);
        return Ok(employe);
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
