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
    public class JobHistoryController : BaseController<JobHistory,JobHistoriesRepository>
    {
        EmployeesRepository employeesRepository;
        JobsRepository jobsRepository;
        DepartmentsRepository departmentsRepository;
        
        public JobHistoryController(JobHistoriesRepository jobHistoriesRepository, EmployeesRepository employeesRepository,JobsRepository jobsRepository,DepartmentsRepository departmentsRepository):base(jobHistoriesRepository)
        {
            this.employeesRepository = employeesRepository;
            this.jobsRepository = jobsRepository;
            this.departmentsRepository = departmentsRepository;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        
    }
}
