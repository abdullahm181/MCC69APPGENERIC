using API.Models;
using API.Repositories.Data;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class UserController : Controller<User, UserRepository>
    {
        UserRepository userRepository;
        private readonly IConfiguration iconfiguration;
        public UserController(UserRepository userRepository, IConfiguration iconfiguration) :base(userRepository)
        {
            this.userRepository = userRepository;
            this.iconfiguration = iconfiguration;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                return BadRequest(new { message = "Username or password is blank" });
            var result = userRepository.Login(user.UserName, user.Password);
            if (result == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            var userRole = userRepository.GetRoleById(result.Id);
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    //new Claim(ClaimTypes.Email, user.Employees.Email),
                    new Claim(ClaimTypes.Name, user.UserName),
                    //new Claim(ClaimTypes.Role, userRole.Role.Name)
                }),
                Expires = DateTime.UtcNow.AddMinutes(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            var data = new
            {
                Id = result.Id,
                UserName = result.UserName,
                FirstName = result.Employees.FirstName,
                LastName = result.Employees.LastName,
                Email = result.Employees.Email,
                Role = userRole.Role.Name,
                Token=tokenString
            };
            return Ok(new { result = 200, message = "successfully Login", data=data });
        }
        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] User user)
        {
            if (!string.IsNullOrWhiteSpace(user.UserName) && !string.IsNullOrWhiteSpace(user.Password)) {
                if (ModelState.IsValid)
                {
                    var result = userRepository.Create(user);
                    if (result > 0)
                        return Ok(new { result = 200, message = "successfully Register" });
                    else if (result == -2)
                        return BadRequest(new { result = 400, message = "UserName sudah digunakan" });
                }
            }
            return BadRequest();  

           
        }

        [HttpPut(" ChangePassword")]
        public IActionResult ChangePassword([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var result = userRepository.ChangePassword(user);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Updated" });
                else if (result == -1)
                    return NotFound(new { message = "Username not registered" });
                /*else if (result == -2)
                    return BadRequest(new { result = 400, message = "UserName sudah digunakan" });*/
            }
            return BadRequest();
        }
        [HttpPut("ForgotPassword")]
        public IActionResult ForgotPassword(User user)
        {
            if (ModelState.IsValid)
            {
                var result = userRepository.ForgotPassword(user);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Updated pasword" });
                else if (result == -1)
                    return NotFound(new { message = "Username not registered" });
            }
            return BadRequest();
        }
    }
}
