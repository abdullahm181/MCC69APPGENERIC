using API.Middleware;
using API.Models;
using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;
        private readonly IConfiguration iconfiguration;
        public AccountController(AccountRepository accountRepository, IConfiguration iconfiguration)
        {
            this.accountRepository = accountRepository;
            this.iconfiguration = iconfiguration;
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                return BadRequest(new { message = "Username or password is blank" });
            var result = accountRepository.Login(user.UserName, user.Password);
            if (result == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            var userRole = accountRepository.GetRoleById(result.Id);
            var jwt = new JwtService(iconfiguration);
            var tokenString = jwt.GenerateSecurityToken(
                result.Id, result.Employees.Email,
                result.Employees.FirstName + " " + result.Employees.LastName,
                userRole.Role.Name);

            return Ok(new { result = 200, message = "successfully Login", Token = tokenString });
        }
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register([FromBody] Register register)
        {
            if (ModelState.IsValid)
            {
                var result = accountRepository.Register(register);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Register" });
                else if (result == -2)
                    return BadRequest(new { result = 400, message = "UserName sudah digunakan" });
            }
            return BadRequest();
        }

        [HttpGet("GetName")]
        public IActionResult GetName()
        {
            var result = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            if (result == null)
                return BadRequest();
            return Ok(new { result = 200, data = result });
        }
        [HttpGet("GetId")]
        public IActionResult GetId()
        {
            var result = HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (result == null)
                return BadRequest();
            return Ok(new { result = 200, data = result });
        }
        [HttpGet("GetEmail")]
        public IActionResult GetEmail()
        {
            var result = HttpContext.User.FindFirst(ClaimTypes.Email)?.Value;
            if (result == null)
                return BadRequest();
            return Ok(new { result = 200, data = result });
        }
        [HttpGet("GetRole")]
        public IActionResult GetRole()
        {
            var result = HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
            if (result == null)
                return BadRequest();
            return Ok(new { result = 200, data = result });
        }

        [HttpPut("ChangePassword")]
        public IActionResult ChangePassword([FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                var result = accountRepository.ChangePassword(user);
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
        public IActionResult ForgotPassword(string email)
        {
            if (ModelState.IsValid)
            {
                var result = accountRepository.ForgotPassword(email);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Updated pasword" });
                else if (result == -1)
                    return NotFound(new { message = "Username not registered" });
            }
            return BadRequest();
        }
    }
}
