using Aplication.Services;
using Aplication.Services.UserServices;
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

namespace Company.UI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [AutoValidateAntiforgeryToken]
    [Authorize]

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
        public async Task<IActionResult> RegisterAsync(UserCreateDto user)
        {
            // Check if the user already exists
            var existingUser = await _userRepository.GetByUserNameAynce(user.Username);
            if (existingUser != null)
            {
                return BadRequest("User already exists");
            }

            // Register the user
            await _userService.CreateUserAynce(user);

            // Generate JWT token for the registered user
            var token = GenerateJwtToken(user.Username);
            return Ok(new TokenDto { AccessToken = token });
        }



        [HttpGet("secure")]
        [Authorize]
        public IActionResult Secure()
        {
            return Ok("Access granted to secure endpoint");
        }




        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            // Here, validate the username and password against your user data  
            var user = await _userRepository.GetUserByUsernameAndPasswordAsync(username, password);
            if (user == null)
            {
                return Unauthorized();  
            }

            // User authentication succeeded, generate JWT token
            var token = GenerateJwtToken(username);
            return Ok(new { token });

        }

        private string GenerateJwtToken(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("KeY1122");
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        [HttpGet("secureUser")]
        [Authorize]
        public IActionResult SecureUser()
        {
            return Ok("Access granted to secure endpoint");
        }



    }
}
