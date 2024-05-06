using Aplication.Services;
using Domen.EmtityDTO.RoleDto;
using Domen.EmtityDTO.UserDto;
using Infrastructure.Repositories;
using Infrastructure.Servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("api/[controller] /[action]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }



        [HttpGet]
        public async Task<IActionResult> GetAllRole()
        {
            List<RoleGetDto> role = await _roleService.GetAllRoleAsync();
            return Ok(role);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdRole(int id)
        {
            var role = await _roleService.GetByIdRoleAsync(id);
            return Ok(role);
        }


        [HttpPost]
        public async Task<RoleGetDto> CreateUser(RoleCreateDto roleCreateDto)
        {
            var role = await _roleService.CreateRoleAsync(roleCreateDto);
            return role;
        }

        [HttpPut]
        public async Task<ActionResult<RoleGetDto>> UpdateUser([FromBody] RoleUpdateDto roleUpdateDto)
        {
            try
            {
                if (roleUpdateDto == null)
                {
                    return BadRequest("User data must be provided.");
                }
                var updatedrole = await _roleService.UpdateRoleAsync(roleUpdateDto);
                if (updatedrole == null)
                {
                    return NotFound($"User with ID {roleUpdateDto.Id} not found.");
                }
                return Ok(updatedrole);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete]
        public async Task<bool> DeleteUser(int Id)
        {
            if (Id != 0)
            {
                return await _roleService.DeleteRoleAsync(Id);
            }
            return false;

        }



    }
}
