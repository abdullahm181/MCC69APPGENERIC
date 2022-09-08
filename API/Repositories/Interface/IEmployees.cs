using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IEmployees
    {
        List<Employees> Get();

        Employees Get(int id);

        int Post(Employees employees);

        int Put(int id, Employees employees);

        int Delete(int id);
    }
}
