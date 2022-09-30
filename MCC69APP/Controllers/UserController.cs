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
           
            return View();
        }
        public IActionResult UnAuthorize() {
            return View();
        }
    }
}
