using Aplication.Services;
using Domen.EmtityDTO.EmployeeDto;
using Domen.EmtityDTO.UserDto;
using Infrastructure.Servises;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserGetDto> user = await  _userService.GetAllUserAynce();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            var user = await _userService.GetByIdUserAynce(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<UserGetDto> CreateUser(UserCreateDto userCreateDto)
        {
            var user = await _userService.CreateUserAynce(userCreateDto);
            return user;
        }

        [HttpPut]
        public async Task<ActionResult<UserGetDto>> UpdateUser([FromBody] UserUpdateDto userUpdateDto)
        {
            try
            {
                if (userUpdateDto == null)
                {
                    return BadRequest("User data must be provided.");
                }
                var updatedUser = await _userService.UpdateUserAynce(userUpdateDto);
                if (updatedUser == null)
                {
                    return NotFound($"User with ID {userUpdateDto.Id} not found.");
                }
                return Ok(updatedUser);
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
                return await _userService.DeleteUserAynce(Id);
            }
            return false;

        }

    }
}
