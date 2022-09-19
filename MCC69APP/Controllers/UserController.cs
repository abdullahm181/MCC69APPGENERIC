using MCC69APP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace MCC69APP.Controllers
{
    public class UserController : Controller
    {
        HttpAPi<User> httpAPI;
        public UserController()
        {
            httpAPI = new HttpAPi<User>("User");
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("Token"))) { 
                
            }
        }
        public IActionResult Index()
        {
            string token = HttpContext.Session.GetString("Token");
            var user = httpAPI.Get(token);

            if (user == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(user);
        }
    }
}
