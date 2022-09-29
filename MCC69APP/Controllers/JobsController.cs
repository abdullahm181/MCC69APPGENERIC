
using MCC69APP.Base;
using MCC69APP.Context;
using MCC69APP.Models;
using MCC69APP.Repositories.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace MCC69APP.Controllers
{
    public class JobsController : BaseController<Jobs,JobsRepository>
    {
       
        public JobsController(JobsRepository jobsRepository):base(jobsRepository)
        {
            
        }
        public IActionResult Index()
        {
            var jobs = GetAll();

            if (jobs == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(jobs);
        }
        
       
    }
}
