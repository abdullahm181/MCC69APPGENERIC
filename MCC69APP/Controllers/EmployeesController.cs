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
    public class EmployeesController : BaseController<Employees, EmployeesRepository>
    {
        DepartmentsRepository departmentsRepository;
        JobsRepository jobsRepository;
        public EmployeesController(EmployeesRepository employeesRepository,DepartmentsRepository departmentsRepository,JobsRepository jobsRepository):base(employeesRepository)
        {
            this.departmentsRepository = departmentsRepository;
            this.jobsRepository = jobsRepository;
        }
        public IActionResult Index()
        {

            var employees =Get();

            if (employees == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(employees);
        }
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var employees = Get(id);
            if (employees == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(employees);
        }
        public IActionResult Create()
        {
            ViewData["Department_Id"] = new SelectList(departmentsRepository.Get(), "Id", "Name");
            ViewData["Job_Id"] = new SelectList(jobsRepository.Get(), "Id", "JobTitle");
            ViewData["Manager_Id"] = new SelectList(Get(), "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,HireDate,Salary,Job_Id,Manager_Id,Department_Id")] Employees employees)
        {
            var result = Post(employees);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(employees);
        }
        public JsonResult Edit(int id)
        {
            if (id == null)
            {
                return Json(null);
            }


            var employees = Get(id);
            if (employees == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

           
            ViewData["Department_Id"] = new SelectList(departmentsRepository.Get(), "Id", "Id", employees.Department_Id);
            ViewData["Job_Id"] = new SelectList(jobsRepository.Get(), "Id", "Id", employees.Job_Id);
            ViewData["Manager_Id"] = new SelectList(Get(), "Id", "Id", employees.Manager_Id);
            return Json(employees);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,FirstName,LastName,Email,PhoneNumber,HireDate,Salary,Job_Id,Manager_Id,Department_Id")] Employees employees)
        {
            var result = Put(employees);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(employees);
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var employees = Get(id);
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

            var result = DeleteEntity(employees);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(employees);
        }
       
    }
}
