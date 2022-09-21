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

            var departments = Get();

            if (departments == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(departments);
        }
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var departments = Get(id);
            if (departments == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(departments);
        }
        public IActionResult Create()
        {
            
            ViewBag.Locations = new SelectList(locationsRepository.Get(), "Id", "StreetAddress");
            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Manager_Id,Location_Id")] Departments departments)
        {
            var result = Post(departments);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(departments);
        }
        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var departments = Get(id);
            if (departments == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            ViewBag.Location_Id= new SelectList(locationsRepository.Get(), "Id", "StreetAddress", departments.Location_Id);
            return View(departments); ;
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,Manager_Id,Location_Id")] Departments departments)
        {
            var result = Put(departments);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(departments);
        }
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var departments = Get(id);
            if (departments == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(departments); ;
        }

        // POST: Departments/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Departments departments)
        {
            var result = DeleteEntity(departments);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(departments);
        }
        
    }
}
