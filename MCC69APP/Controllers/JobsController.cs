
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
            var jobs = Get();

            if (jobs == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(jobs);
        }
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobs = Get(id);
            if (jobs == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(jobs);
        }
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,JobTitle,MinSalary,MaxSalary")] Jobs jobs)
        {
            var result =Post(jobs);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(jobs);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobs = Get(id);
            if (jobs == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(jobs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,JobTitle,MinSalary,MaxSalary")] Jobs jobs)
        {
            var result = Put(jobs);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(jobs);
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobs = Get(id);
            if (jobs == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(jobs);
        }

        // POST: Jobs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Jobs jobs)
        {
            var result = DeleteEntity(jobs);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(jobs);

        }
       
    }
}
