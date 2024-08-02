using Aplication.Services.EmployeeServices;
using Aplication.Services.Excel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("api/[action]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;
        private readonly IEmployeeService _employeeService;

        public PersonController(IPersonService personService, IEmployeeService employeeService)
        {
            _personService = personService;
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPersons()
        {
            var persons = await _employeeService.GetAllEmployeesAsync();
            return Ok(persons);
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportToExcel()
        {
            var persons = await _employeeService.GetAllEmployeesAsync();
            await _employeeService.EmployeeCreateExcelFileAsync(persons);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "D:\\hp.xlsx");

            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "D:\\hp.xlsx");
        }
    }
}
