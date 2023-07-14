using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using MiniFapAPI.DTO;
using MiniFapAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MiniFapAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IConfiguration _configuration;
        private readonly MiniFap5Context _context;
        public UserController(IConfiguration configuration, MiniFap5Context context)
        {
            _configuration= configuration;
            _context= context;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(LoginModel model)
        {
            IActionResult respone = Unauthorized();
            var user = _context.Users.Include("Role").FirstOrDefault(x=>x.Email==model.Email && x.Password==model.Password);
            if (user != null)
            {
                var issuer = _configuration["Jwt:Issuer"];
                var audience = _configuration["Jwt:Audience"];
                var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
                var signingCredential = new SigningCredentials(
                    new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature
                    );
                var subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim(ClaimTypes.Role, user.Role.RoleName)
                });

                var expires = DateTime.UtcNow.AddDays(1);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = subject,
                    Expires = expires,
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = signingCredential
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken = tokenHandler.WriteToken(token);
                var objReturn = new
                {
                    token = jwtToken
                };
                return Ok(objReturn);
            }
            else
            {
                return NotFound("Invalid user name or password.");
            }
            return respone;
        }
    }
}
