using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UsersAPI.Models;

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

		[AllowAnonymous]
        [HttpPost] 
        public IActionResult RequestToken([FromBody] User request)
        {

            if (request.Name == "Mac" && request.Password == "123456")
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Name, request.Name)
                };
                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["SecurityKey"])
                );
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var token = new JwtSecurityToken(
                    issuer: "usersapi.net",
                    audience: "usersapi.net",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds
                );

				return Ok(new 
				{
					token = new JwtSecurityTokenHandler().WriteToken(token)
				});
            }
            return BadRequest("Invalid credentials ...");
        }
    }
}
