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
                return BadRequest();
            var result = userRepository.Login(user.UserName, user.Password);
            if (result == null)
                return NotFound();
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

        [HttpPut("Change/{id}")]
        public IActionResult Update(int id, [FromBody] User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = id;
                var result = userRepository.Update(user);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Updated" });
                else if (result == -1)
                    return NotFound();
                else if (result == -2)
                    return BadRequest(new { result = 400, message = "UserName sudah digunakan" });
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
                    return NotFound();
            }
            return BadRequest();
        }
    }
}
