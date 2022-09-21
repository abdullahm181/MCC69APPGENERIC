using MCC69APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Repositories.Data
{
    public class UserRepository : GeneralRepository<User>
    {
        public UserRepository(string request = "User/") : base(request)
        {

        }
    }
}
