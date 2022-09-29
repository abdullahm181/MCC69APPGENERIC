using MCC69APP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using MCC69APP.Repositories.Data;
using MCC69APP.Base;

namespace MCC69APP.Controllers
{
    public class UserController : BaseController<User, UserRepository>
    {
       
        public UserController(UserRepository userRepository):base(userRepository)
        {
            
            
        }
        public IActionResult Index()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Token")))
            {
                return View("UnAuthorize");
            }
            //string token = HttpContext.Session.GetString("Token");
            var user = GetAll();

            if (user == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(user);
        }
        public IActionResult UnAuthorize() {
            return View();
        }
    }
}
