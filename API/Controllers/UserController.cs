using API.Middleware;
using API.Models;
using API.Repositories.Data;
using API.ViewModels;
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
        
        public UserController(UserRepository userRepository) :base(userRepository)
        {
           
        }
        
    }
}
