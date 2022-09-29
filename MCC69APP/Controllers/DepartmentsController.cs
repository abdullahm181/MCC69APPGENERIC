using MCC69APP.Base;
using MCC69APP.Context;
using MCC69APP.Models;
using MCC69APP.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MCC69APP.Controllers
{
    public class DepartmentsController : BaseController<Departments, DepartmentsRepository>
    {
        LocationsRepository locationsRepository;
        public DepartmentsController(DepartmentsRepository departmentsRepository,LocationsRepository locationsRepository):base(departmentsRepository)
        {
            this.locationsRepository = locationsRepository;
        }
        public IActionResult Index()
        {

            var departments = GetAll();

            if (departments == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(departments);
        }
        
        
    }
}
