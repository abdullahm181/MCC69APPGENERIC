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
            var jobHistories = Get();

            if (jobHistories == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(jobHistories);
        }
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobHistory = Get(id);
            if (jobHistory == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(jobHistory);
        }
        public IActionResult Create()
        {
            ViewData["Department_Id"] = new SelectList(departmentsRepository.Get(), "Id", "Name");
            ViewData["Id"] = new SelectList(employeesRepository.Get(), "Id","Id");
            ViewData["Job_Id"] = new SelectList(jobsRepository.Get(), "Id", "JobTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StartDate,EndDate,Job_Id,Department_Id")] JobHistory jobHistories)
        {
            var result = Post(jobHistories);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(jobHistories);
        }
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobHistory = Get(id);
            if (jobHistory == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

           
            ViewData["Department_Id"] = new SelectList(departmentsRepository.Get(), "Id", "Id", jobHistory.Department_Id);
            //ViewData["Id"] = new SelectList(httpAPIEmployees.Get().ToList(), "Id", "Id", jobHistory.Id);
            ViewData["Job_Id"] = new SelectList(jobsRepository.Get(), "Id", "Id", jobHistory.Job_Id);
            return View(jobHistory);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,StartDate,EndDate,Job_Id,Department_Id")] JobHistory jobHistories)
        {
            var result = Put(jobHistories);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(jobHistories);
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobHistory = Get(id);
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
            var result = DeleteEntity(jobHistory);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(jobHistory);
        }
       
    }
}
