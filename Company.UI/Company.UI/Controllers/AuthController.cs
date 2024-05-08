using Aplication.Services;
using Domen.Model;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Company.UI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AutoValidateAntiforgeryToken]
    [Authorize]
    
    public class AuthController : ControllerBase

    {
        private readonly IUserService _userService;
        private readonly IUserRepository  _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }





        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            if (user.UserName =="a" && user.Password == "a")
            {
                // Ensure the key length is sufficient for HS256
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Key@0204"));
                var signinKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Secret phase"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7246", // Specify the issuer
                    audience: "https://localhost:7246", // Specify the audience
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new AuthenticatedResponse { Token = tokenString });
            }

            return Unauthorized();
        }
    }
}
