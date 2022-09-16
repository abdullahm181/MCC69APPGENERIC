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
        MyContext myContext;
        public JobHistoryController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            var data = myContext.JobHistory.Include(j => j.Departments).Include(j => j.Jobs).Include(j => j.Employees).ToList();
            return View(data);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data=myContext.JobHistory.Include(j => j.Departments)
                .Include(j => j.Employees)
                .Include(j => j.Jobs)
                .FirstOrDefault(m => m.Id == id);
            
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        public IActionResult Create()
        {
            ViewData["Department_Id"] = new SelectList(myContext.Departments, "Id", "Name");
            ViewData["Id"] = new SelectList(myContext.Employees, "Id","Id");
            ViewData["Job_Id"] = new SelectList(myContext.Jobs, "Id", "JobTitle");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StartDate,EndDate,Job_Id,Department_Id")] JobHistory jobHistories)
        {
            if (ModelState.IsValid)
            {
                myContext.Add(jobHistories);
                var result=myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["Department_Id"] = new SelectList(myContext.Departments, "Id", "Id", jobHistories.Department_Id);
            ViewData["Id"] = new SelectList(myContext.Employees, "Id", "Id", jobHistories.Id);
            ViewData["Job_Id"] = new SelectList(myContext.Jobs, "Id", "Id", jobHistories.Job_Id);
            return View(jobHistories);
        }
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var data = myContext.JobHistory.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            ViewData["Department_Id"] = new SelectList(myContext.Departments, "Id", "Id", data.Department_Id);
            ViewData["Id"] = new SelectList(myContext.Employees, "Id", "Id", data.Id);
            ViewData["Job_Id"] = new SelectList(myContext.Jobs, "Id", "Id", data.Job_Id);
            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,StartDate,EndDate,Job_Id,Department_Id")] JobHistory jobHistories)
        {
            if (id != jobHistories.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    myContext.Update(jobHistories);
                    var result = myContext.SaveChanges();
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobHistoryExists(jobHistories.Id))
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
            ViewData["Department_Id"] = new SelectList(myContext.Departments, "Id", "Id", jobHistories.Department_Id);
            ViewData["Id"] = new SelectList(myContext.Employees, "Id", "Id", jobHistories.Id);
            ViewData["Job_Id"] = new SelectList(myContext.Jobs, "Id", "Id", jobHistories.Job_Id);
            return View(jobHistories);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = myContext.JobHistory
                .Include(j => j.Departments)
                .Include(j => j.Employees)
                .Include(j => j.Jobs)
                .FirstOrDefault(m => m.Id == id);
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
            var data = myContext.JobHistory.Find(id);
            myContext.JobHistory.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction(nameof(Index));
            return View();
        }
        private bool JobHistoryExists(int id)
        {
            return myContext.JobHistory.Any(e => e.Id == id);
        }
    }
}
