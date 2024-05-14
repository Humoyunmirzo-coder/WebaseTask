using Aplication.Services.RoleServices;
using AutoMapper;
using Domen.EmtityDTO.RoleDto;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("api/[controller] /[action]")]
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
            var role = await _roleService.GetByIdRoleAsync(id);
            return Ok(role);
        }

        [HttpPost]
        public async Task<RoleGetDto> CreateRole(RoleCreateDto roleCreateDto)
        {
            var task = await _roleService.CreateRoleAsync(roleCreateDto);
            return task;
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

        [HttpDelete]
        public async Task<bool> DeleteRoler(int Id)
        {
            if (Id != 0)
            {
                return await _roleService.DeleteRoleAsync(Id);
            }
            return false;

        }


    }
}
