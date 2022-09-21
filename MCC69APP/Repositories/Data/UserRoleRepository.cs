﻿using MCC69APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Repositories.Data
{
    public class UserRoleRepository : GeneralRepository<UserRole>
    {
        public UserRoleRepository(string request = "UserRole/") : base(request)
        {
                
        }
    }
}
