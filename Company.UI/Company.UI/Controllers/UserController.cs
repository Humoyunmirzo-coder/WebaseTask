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
