using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UserController : Controller<User, UserRepository>
    {
        UserRepository userRepository;
        public UserController(UserRepository userRepository):base(userRepository)
        {
            this.userRepository = userRepository;
        }
        //[AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(User user)
        {
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
                return BadRequest(new { message = "Username or password is blank" });
            var result = userRepository.Login(user.UserName, user.Password);
            if (result == null)
                return BadRequest(new { message = "Username or password is incorrect" });
            return Ok(new { result = 200, message = "successfully Login" });
        }
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
