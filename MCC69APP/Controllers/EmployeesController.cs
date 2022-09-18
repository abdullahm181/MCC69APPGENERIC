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
    public class EmployeesController : Controller
    {
        HttpAPi<Employees> httpAPI;
        HttpAPi<Departments> httpAPIDepartments;
        HttpAPi<Jobs> httpAPIJobs;
        public EmployeesController(MyContext myContext)
        {
            this.httpAPI = new HttpAPi<Employees>("Employees");
            this.httpAPIDepartments = new HttpAPi<Departments>("Departments");
            this.httpAPIJobs = new HttpAPi<Jobs>("Jobs");
        }
        public IActionResult Index()
        {

            var employees = httpAPI.Get().ToList();

            if (employees == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(employees);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var employees = httpAPI.Get(id);
            if (employees == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(employees);
        }
        public IActionResult Create()
        {
            ViewData["Department_Id"] = new SelectList(httpAPIDepartments.Get().ToList(), "Id", "Name");
            ViewData["Job_Id"] = new SelectList(httpAPIJobs.Get().ToList(), "Id", "JobTitle");
            ViewData["Manager_Id"] = new SelectList(httpAPI.Get().ToList(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,HireDate,Salary,Job_Id,Manager_Id,Department_Id")] Employees employees)
        {
            string result = httpAPI.Create(employees);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(employees);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var employees = httpAPI.Get(id);
            if (employees == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

           
            ViewData["Department_Id"] = new SelectList(httpAPIDepartments.Get().ToList(), "Id", "Id", employees.Department_Id);
            ViewData["Job_Id"] = new SelectList(httpAPIJobs.Get().ToList(), "Id", "Id", employees.Job_Id);
            ViewData["Manager_Id"] = new SelectList(httpAPI.Get().ToList(), "Id", "Id", employees.Manager_Id);
            return View(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,FirstName,LastName,Email,PhoneNumber,HireDate,Salary,Job_Id,Manager_Id,Department_Id")] Employees employees)
        {
            string result = httpAPI.Edit(employees);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var employees = httpAPI.Get(id);
            if (employees == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(employees);
        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Employees employees)
        {

            string result = httpAPI.Delete(employees);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(employees);
        }
       
    }
}
