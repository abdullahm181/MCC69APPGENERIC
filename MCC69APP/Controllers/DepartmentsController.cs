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
    public class DepartmentsController : Controller
    {
        HttpAPi<Departments> httpAPI;
        HttpAPi<Locations> httpAPILocations;
        public DepartmentsController(MyContext myContext)
        {
            this.httpAPI = new HttpAPi<Departments>("Departments");
            this.httpAPILocations = new HttpAPi<Locations>("Locations");
        }
        public IActionResult Index()
        {

            var departments = httpAPI.Get().ToList();

            if (departments == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(departments);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var departments = httpAPI.Get(id);
            if (departments == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(departments);
        }
        public IActionResult Create()
        {
            
            ViewBag.Locations = new SelectList(httpAPILocations.Get().ToList(), "Id", "StreetAddress");
            
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Manager_Id,Location_Id")] Departments departments)
        {
            string result = httpAPI.Create(departments);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(departments);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var departments = httpAPI.Get(id);
            if (departments == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            ViewBag.Location_Id= new SelectList(httpAPILocations.Get().ToList(), "Id", "StreetAddress", departments.Location_Id);
            return View(departments); ;
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,Name,Manager_Id,Location_Id")] Departments departments)
        {
            string result = httpAPI.Edit(departments);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }
            return View(departments);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var departments = httpAPI.Get(id);
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
            string result = httpAPI.Delete(departments);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(departments);
        }
        
    }
}
