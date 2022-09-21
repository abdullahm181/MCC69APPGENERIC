using MCC69APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Repositories.Data
{
    public class RoleRepository : GeneralRepository<Role>
    {
        public RoleRepository(string request = "Role/") : base(request)
        {

        }
    }
}
