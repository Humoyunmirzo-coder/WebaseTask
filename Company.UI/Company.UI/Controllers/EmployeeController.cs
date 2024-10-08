﻿using Aplication.Services.EmployeeServices;
using Domen.AutoGenerated;
using Domen.EmtityDTO.EmployeeDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;
    private readonly Logger <Employee> _logger;

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
    [Authorize]
    public async Task<IActionResult> GetByIdEmployee(int id)
    {
        try
        {
            var employee = await _employeeService.GetByIdEmployeeAsync(id);
            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while retrieving employee by ID: {Id}", id);
            return StatusCode(500, "Internal Server Error"); 
        }
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        try
        {
            if (id != 0)
            {
                var isDeleted = await _employeeService.DeleteEmployeeAsync(id);
                if (isDeleted)
                {
                    return Ok(true);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return BadRequest("Invalid employee ID");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while deleting employee with ID: {Id}", id);
            return StatusCode(500, "Internal Server Error"); 
        }
    }
    [HttpGet("export")]
    public async Task<IActionResult> AllEmpoyeeExportToExcel()
    {
        var persons = await _employeeService.GetAllEmployeesAsync();
        await _employeeService.EmployeeCreateExcelFileAsync(persons);
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "D:\\hp.xlsx");

        byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
        return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "D:\\hp.xlsx");
    }

}
