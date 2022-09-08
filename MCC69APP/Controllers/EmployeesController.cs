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
        MyContext myContext;
        public EmployeesController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            
            var data = myContext.Employees.Include(x => x.Departments).Include(x => x.Jobs).ToList();
            /*var manager = myContext.Employees.Where(x => x.Manager_Id != null).ToList();
            var result = data.Join(manager, x => x, y => y, (x, y) => x).ToList();*/
            
            //var data = myContext.Employees.Include(e => e.Departments).Include(e => e.Jobs).ToList();
            return View(data);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = myContext.Employees.Include(e => e.Departments).Include(e => e.Jobs).SingleOrDefault(x => x.Id.Equals(id));
            
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        public IActionResult Create()
        {
            ViewData["Department_Id"] = new SelectList(myContext.Departments, "Id", "Name");
            ViewData["Job_Id"] = new SelectList(myContext.Jobs, "Id", "JobTitle");
            ViewData["Manager_Id"] = new SelectList(myContext.Employees, "Id", "Id");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,FirstName,LastName,Email,PhoneNumber,HireDate,Salary,Job_Id,Manager_Id,Department_Id")] Employees employees)
        {
            if (ModelState.IsValid)
            {
                myContext.Employees.Add(employees);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["Department_Id"] = new SelectList(myContext.Departments, "Id", "Id", employees.Department_Id);
            ViewData["Job_Id"] = new SelectList(myContext.Jobs, "Id", "Id", employees.Job_Id);
            ViewData["Manager_Id"] = new SelectList(myContext.Employees, "Id", "Id", employees.Manager_Id);
            return View(employees);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = myContext.Employees.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            ViewData["Department_Id"] = new SelectList(myContext.Departments, "Id", "Id", data.Department_Id);
            ViewData["Job_Id"] = new SelectList(myContext.Jobs, "Id", "Id", data.Job_Id);
            ViewData["Manager_Id"] = new SelectList(myContext.Employees, "Id", "Id", data.Manager_Id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,FirstName,LastName,Email,PhoneNumber,HireDate,Salary,Job_Id,Manager_Id,Department_Id")] Employees employees)
        {
            if (id != employees.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    myContext.Employees.Update(employees);
                    var result=myContext.SaveChanges();
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeesExists(employees.Id))
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
            ViewData["Department_Id"] = new SelectList(myContext.Departments, "Id", "Id", employees.Department_Id);
            ViewData["Job_Id"] = new SelectList(myContext.Jobs, "Id", "Id", employees.Job_Id);
            ViewData["Manager_Id"] = new SelectList(myContext.Employees, "Id", "Id", employees.Manager_Id);
            return View(employees);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var data= myContext.Employees.Include(e => e.Jobs).Include(e => e.Departments).Include(e => e.Manager).FirstOrDefault(m => m.Id == id);
    
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

 
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var data = myContext.Employees.Find(id);
            myContext.Employees.Remove(data);
            var result=myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction(nameof(Index));
            return View();
        }
        private bool EmployeesExists(int id)
        {
            return myContext.Employees.Any(e => e.Id == id);
        }
    }
}
