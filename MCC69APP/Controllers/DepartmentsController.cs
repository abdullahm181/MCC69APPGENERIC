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
        MyContext myContext;
        public DepartmentsController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            var data = myContext.Departments.Include(d => d.Locations).ToList();
            return View(data);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = myContext.Departments.Include(d => d.Locations).FirstOrDefault(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        public IActionResult Create()
        {

            ViewBag.Locations = new SelectList(myContext.Locations.ToList(), "Id", "StreetAddress");
            ViewData["Manager_Id"] = new SelectList(myContext.Employees.ToList(), "Id", "Id");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Manager_Id,Location_Id")] Departments departments)
        {
            if (ModelState.IsValid)
            {
                myContext.Departments.Add(departments);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["Location_Id"] = new SelectList(myContext.Locations, "Id", "StreetAddress", departments.Location_Id);
            
            return View(departments);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var departments = myContext.Departments.Find(id);
            if (departments == null)
            {
                return NotFound();
            }
            ViewData["Location_Id"] = new SelectList(myContext.Locations, "Id", "StreetAddress", departments.Location_Id);
            
            return View(departments);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Manager_Id,Location_Id")] Departments departments)
        {
            if (id != departments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    myContext.Departments.Update(departments);
                    var result = myContext.SaveChanges();
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DepartmentsExists(departments.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Location_Id"] = new SelectList(myContext.Locations, "Id", "StreetAddress", departments.Location_Id);
            
            return View(departments);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var data = myContext.Departments.Include(d => d.Locations).FirstOrDefault(m => m.Id == id);
            
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var data = myContext.Departments.Find(id);
            myContext.Departments.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction(nameof(Index));
            return View();
        }
        private bool DepartmentsExists(int id)
        {
            return myContext.Departments.Any(e => e.Id == id);
        }
    }
}
