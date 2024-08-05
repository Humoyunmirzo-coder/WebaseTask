using Aplication.Services.RoleServices;
using AutoMapper;
using Domen.EmtityDTO.RoleDto;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("api /[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;
        private readonly IMapper _mapper;

        public RoleController(IRoleService roleService, IMapper mapper)
        {
            _roleService = roleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            List<RoleGetDto> task = await _roleService.GetAllRoleAsync();
            return Ok(task);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdRole(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid role ID.");
            }
            try
            {
                var role = await _roleService.GetByIdRoleAsync(id);

                if (role == null)
                {
                    return NotFound($"Role with ID {id} not found.");
                }
                return Ok(role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] RoleCreateDto roleCreateDto)
        {
            if (roleCreateDto == null)
            {
                return BadRequest("Role data must be provided.");
            }

            try
            {
                var role = await _roleService.CreateRoleAsync(roleCreateDto);

                if (role == null)
                {
                    return StatusCode(500, "An error occurred while creating the role.");
                }

                return CreatedAtAction(nameof(GetByIdRole), new { id = role.Id }, role);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


        [HttpPut]
        public async Task<ActionResult<RoleGetDto>> UpdateRole([FromBody] RoleUpdateDto roleUpdateDto)
        {
            try
            {
                if (roleUpdateDto == null)
                {
                    return BadRequest("role data must be provided.");
                }
                var updatedUser = await _roleService.UpdateRoleAsync(roleUpdateDto);
                if (updatedUser == null)
                {
                    return NotFound($"role with ID {roleUpdateDto.Id} not found.");
                }
                return Ok(updatedUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoler(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid role ID.");
            }

            try
            {
                var roleExists = await _roleService.GetByIdRoleAsync(id);
                if (roleExists == null)
                {
                    return NotFound($"Role with ID {id} not found.");
                }

                var result = await _roleService.DeleteRoleAsync(id);
                if (result)
                {
                    return NoContent(); // Successful deletion, 204 No Content
                }
                else
                {
                    return StatusCode(500, "An error occurred while deleting the role.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
        [HttpGet("export")]
        public async Task<IActionResult> AllRoleExportToExcel()
        {
            var persons = await _roleService.GetAllRoleAsync();
            await _roleService.RoleCreateExcelFileAsync(persons);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "D:\\hp.xlsx");

            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "D:\\hp.xlsx");
        }



    }
}
