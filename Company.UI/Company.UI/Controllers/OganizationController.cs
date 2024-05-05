using Aplication.Services;
using Domen.EmtityDTO.EmployeeDto;
using Domen.EmtityDTO.OrganizationDto;
using Infrastructure.Repositories;
using Infrastructure.Servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("[controller] / [action]")]
    [ApiController]
    public class OganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;

        public OganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrganization() 
        { 
            List<OrganizationGetDto> organization = await _organizationService.GetAllOrganizationAsync();
            return Ok(organization);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdOrganization(int id)
        {
            var organization = await _organizationService.GetByIdOrganizationAsync(id);
            return Ok(organization);
        }

        [HttpPost]
        public async Task<OrganizationGetDto> CreateEmployee(OrganizationCreateDto organizationCreateDto)
        {
            var organization = await _organizationService.CreateOrganizationAsync(organizationCreateDto);
            return organization;
        }
        [HttpDelete("{id:int}")] 
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            if (id <= 0)  
            {
                return BadRequest("Invalid ID supplied.");
            }
            try
            {
                var result = await _organizationService.DeleteOrganizationAsync(id);
                if (result)
                {
                    return Ok($"Employee with ID {id} deleted successfully.");
                }
                else
                {
                    return NotFound($"Employee with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message) ;
            }
        }

    }
}
