using Aplication.Services;
using Domen.EmtityDTO.EmployeeDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService  ;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
 

    }
}
