using API.Models;
using API.Repositories.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class RoleController : Controller<Role, RoleRepository>
    {
        public RoleController(RoleRepository roleRepository):base(roleRepository)
        {

        }
    }
}
