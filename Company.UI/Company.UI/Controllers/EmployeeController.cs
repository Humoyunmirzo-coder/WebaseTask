﻿using Aplication.Services;
using Domen.AutoGenerated;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        //private readonly ICompanyService _companyService;

        //public EmployeeController(ICompanyService companyService)
        //{
        //    _companyService = companyService;
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        //{
        //    var employees = await _companyService.GetAllEmployeeAynce();
        //    return Ok(employees);
        //}
        //// Employee qaytarish uchun GET metodini taqdim etish mumkin.
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Employee>> GetEmployee(int id)
        //{
        //    var employee = await _companyService.GetByIdEmployee(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return employee;
        //}


        //[HttpGet("{id}")]
        //public async Task<ActionResult<Employee>> GetByIdEmployee(int id)
        //{
        //    var employee = await _companyService.GetByIdEmployee(id);
        //    if (employee == null)
        //    {
        //        return NotFound();
        //    }
        //    return Ok(employee);
        //}

       
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        //{
        //    if (id != employee.Id)
        //    {
        //        return BadRequest();
        //    }
        //    await _companyService.UpdateEmployeeAynce(employee);
        //    return NoContent();
        //}

        //[HttpPost]
        //public async Task<ActionResult<Employee>> CreateEmployee(Employee employee)
        //{
        //    if (employee == null)
        //    {
        //        return BadRequest("Malumot yetarli emas.");
        //    }
        //    // Bu yerda biz email manzilining noyobligini tekshiramiz.
        //    var existingEmployee = await _companyService.GetByIdEmployee(employee.Id);
        //    if (existingEmployee != null)
        //    {
        //        return BadRequest("Bu Id bilan allaqachon ro'yxatdan o'tilgan.");
        //    }
         
        //    try
        //    {
        //        await _companyService.CreateEmployeeAynce(employee);
        //        return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, "Xodim yaratishda xatolik yuz berdi: " + ex.Message);
        //    }
        //}
    

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteEmployee(int id)
        //{
        //    var success = await _companyService.DeleteEmployeeAynce(id);
        //    if (!success)
        //    {
        //        return NotFound();
        //    }
        //    return NoContent();
        //}
    }
}
