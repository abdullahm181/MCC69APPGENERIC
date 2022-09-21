using MCC69APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Repositories.Data
{
    public class EmployeesRepository : GeneralRepository<Employees>
    {
        public EmployeesRepository(string request = "Employees/") : base(request)
        {

        }
    }
}
