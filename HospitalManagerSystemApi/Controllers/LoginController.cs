using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace HospitalManagerSystemApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] LoginUser userLogin)
        {
            var user = Authenticate(userLogin);

            if (user != null)
            {
                string token = Generate(user);
           

                return Ok(token);
            }
            return NotFound("User not found");
        }

        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Surname,user.Surname),
                new Claim(ClaimTypes.Name,user.Name),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Role,user.Role),
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddSeconds(20),
                signingCredentials: credentials);

    

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User Authenticate(LoginUser userLogin)
        {
            using var c = new Context();
            var currentUser = c.Users.FirstOrDefault(ba => ba.Email.ToLower() == userLogin.Email.ToLower()
            && ba.Password == userLogin.Password);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
