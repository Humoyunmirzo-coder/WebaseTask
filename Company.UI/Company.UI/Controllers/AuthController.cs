using Aplication.Services;
using Aplication.Services.Token;
using Aplication.Services.UserServices;
using Aplication.Servises;
using Domen.EmtityDTO.Token;
using Domen.EmtityDTO.UserDto;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company.UI.Controllers;

[Route("[action]")]
[ApiController]


public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IUserRepository _userRepository;
    private readonly ConpanyDbContext _conpanyDbContext;

    public AuthController(IUserRepository userRepository, ConpanyDbContext conpanyDbContext, IUserService userService)
    {
        _userRepository = userRepository;
        _conpanyDbContext = conpanyDbContext;
        _userService = userService;
    }


    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserCreateDto createUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Notori nimadir boldi");
        }
        var user = await _userService.RegisterAsync(createUser);

        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginUserModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Notori nimadir boldi");
        }

        return Ok(new { Token = await _userService.LoginAsync(loginUserModel) });
    }


/*    [HttpPost]
    public async Task<IActionResult> Login(string username, string password)
    {
        // Here, validate the username and password against your user data  
        var user = await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);
        if (user == null)
        {
            return Unauthorized();  
        }

        // User authentication succeeded, generate JWT token
        var token = _tokenService.GenerateJwtToken(username);
        return Ok(new { token });

    }*/


    [HttpGet("secureUser")]
    [Authorize]
    public IActionResult SecureUser()
    {
        return Ok("Access granted to secure endpoint");
    }



}
