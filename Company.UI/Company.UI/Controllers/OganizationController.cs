using Aplication.Services.OrganizationServices;
using Domen.EmtityDTO.OrganizationDto;
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
        public async Task<OrganizationGetDto> CreateOrganization(OrganizationCreateDto organizationCreateDto)
        {
            var organization = await _organizationService.CreateOrganizationAsync(organizationCreateDto);
            return organization;
        }

        [HttpPut]

        public async Task<ActionResult<OrganizationGetDto>> UpdateOrganization([FromBody] OrganizationUpdateDto organizationUpdate)
        {
            try
            {
                if (organizationUpdate == null)
                {
                    return BadRequest("organizationUpdate data must be provided.");
                }
                var updatedUser = await _organizationService.UpdateOrganizationAsync(organizationUpdate);
                if (updatedUser == null)
                {
                    return NotFound($"Organization with ID {organizationUpdate.Id} not found.");
                }
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
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
                return StatusCode(500, ex.Message);
            }
        }

    }
}
