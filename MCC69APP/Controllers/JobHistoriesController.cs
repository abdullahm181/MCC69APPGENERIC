using MCC69APP.Context;
using MCC69APP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Controllers
{
    public class JobHistoryController : Controller
    {
        HttpAPi<Employees> httpAPIEmployees;
        HttpAPi<JobHistory> httpAPI;
        HttpAPi<Jobs> httpAPIJobs;
        HttpAPi<Departments> httpAPIDepartments;
        public JobHistoryController(MyContext myContext)
        {
            this.httpAPIEmployees = new HttpAPi<Employees>("Employees");
            this.httpAPI = new HttpAPi<JobHistory>("JobHistory");
            this.httpAPIDepartments = new HttpAPi<Departments>("Departments");
            this.httpAPIJobs = new HttpAPi<Jobs>("Jobs");
        }
        public IActionResult Index()
        {
            var jobHistories = httpAPI.Get().ToList();

            if (jobHistories == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(jobHistories);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobHistory = httpAPI.Get(id);
            if (jobHistory == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(jobHistory);
        }
        public IActionResult Create()
        {
            ViewData["Department_Id"] = new SelectList(httpAPIDepartments.Get().ToList(), "Id", "Name");
            ViewData["Id"] = new SelectList(httpAPIEmployees.Get().ToList(), "Id","Id");
            ViewData["Job_Id"] = new SelectList(httpAPIJobs.Get().ToList(), "Id", "JobTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StartDate,EndDate,Job_Id,Department_Id")] JobHistory jobHistories)
        {
            string result = httpAPI.Create(jobHistories);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(jobHistories);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobHistory = httpAPI.Get(id);
            if (jobHistory == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

           
            ViewData["Department_Id"] = new SelectList(httpAPIDepartments.Get().ToList(), "Id", "Id", jobHistory.Department_Id);
            //ViewData["Id"] = new SelectList(httpAPIEmployees.Get().ToList(), "Id", "Id", jobHistory.Id);
            ViewData["Job_Id"] = new SelectList(httpAPIJobs.Get().ToList(), "Id", "Id", jobHistory.Job_Id);
            return View(jobHistory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,StartDate,EndDate,Job_Id,Department_Id")] JobHistory jobHistories)
        {
            string result = httpAPI.Edit(jobHistories);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }
            return View(jobHistories);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobHistory = httpAPI.Get(id);
            if (jobHistory == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(jobHistory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(JobHistory jobHistory)
        {
            string result = httpAPI.Delete(jobHistory);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(jobHistory);
        }
       
    }
}
