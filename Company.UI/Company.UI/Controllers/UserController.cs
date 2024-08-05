using Aplication.Services.UserServices;
using Domen.EmtityDTO.UserDto;
using Microsoft.AspNetCore.Mvc;

namespace Company.UI.Controllers
{
    [Route("api/[action]")]
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
            List<UserGetDto> user = await _userService.GetAllUserAynce();
            return Ok(user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid user ID.");
            }

            try
            {
                var user = await _userService.GetByIdUserAynce(id);

                if (user == null)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userCreateDto)
        {
            if (userCreateDto == null)
            {
                return BadRequest("User data must be provided.");
            }

            try
            {
                var createdUser = await _userService.CreateUserAynce(userCreateDto);
                if (createdUser == null)
                {
                    return StatusCode(500, "Failed to create the user.");
                }

                return CreatedAtAction(nameof(GetByIdUser), new { id = createdUser.Id }, createdUser);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (id == 0)
            {
                return BadRequest("Invalid ID. ID must be greater than 0.");
            }

            try
            {
                var result = await _userService.DeleteUserAynce(id);
                if (!result)
                {
                    return NotFound($"User with ID {id} not found.");
                }

                return Ok($"User with ID {id} has been successfully deleted.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while deleting the user: {ex.Message}");
            }
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportToExcel()
        {
            var persons = await _userService.GetAllUserAynce();
            await _userService.UserCreateExcelFileAsync(persons);
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "D:\\hp.xlsx");

            byte[] fileBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(fileBytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "D:\\hp.xlsx");
        }

    }
}
