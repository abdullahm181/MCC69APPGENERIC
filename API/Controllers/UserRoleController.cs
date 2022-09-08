using API.Models;
using API.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class UserRoleController : Controller<UserRole, UserRoleRepository>
    {
        public UserRoleController(UserRoleRepository userRoleRepository): base(userRoleRepository)
        {

        }
    }
}
