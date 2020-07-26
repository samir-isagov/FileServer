using System;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using FileServer.WebAPI.Dtos;
using Microsoft.Extensions.Configuration;

namespace FileServer.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult LogIn(UserForLoginDto userForLoginDto)
        {
            int storedUserId = 1;
            string storedUsername = "esdas";
            string storedPassword = "kulpin123";

            if (userForLoginDto.Username != storedUsername || userForLoginDto.Password != storedPassword)
            {
                return Unauthorized();
            }

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, storedUserId.ToString()),
                new Claim(ClaimTypes.Name, storedUsername)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
#if DEBUG
                Expires = DateTime.Now.AddYears(1),
#else
                Expires = DateTime.Now.AddDays(1),
#endif
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new
            {
                token = tokenHandler.WriteToken(token)
            });
        }
    }
}