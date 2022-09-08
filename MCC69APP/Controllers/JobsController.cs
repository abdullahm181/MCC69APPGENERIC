
using MCC69APP.Context;
using MCC69APP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Controllers
{
    public class JobsController : Controller
    {
        MyContext myContext;
        public JobsController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            return View(myContext.Jobs.ToList());
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = myContext.Jobs.FirstOrDefault(m => m.Id == id);
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,JobTitle,MinSalary,MaxSalary")] Jobs jobs)
        {
            if (ModelState.IsValid)
            {
                myContext.Jobs.Add(jobs);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(jobs);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data =myContext.Jobs.Find(id);
            if (data == null)
            {
                return NotFound();
            }
            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,JobTitle,MinSalary,MaxSalary")] Jobs jobs)
        {
            if (id != jobs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    myContext.Entry(jobs).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    var result = myContext.SaveChanges();
                    if (result > 0)
                        return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JobsExists(jobs.Id))
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
            return View(jobs);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = myContext.Jobs.FirstOrDefault(m => m.Id == id);  
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // POST: Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var jobs =myContext.Jobs.Find(id);
            myContext.Jobs.Remove(jobs);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction(nameof(Index));
            return View();
            
        }
        private bool JobsExists(int id)
        {
            return myContext.Jobs.Any(e => e.Id == id);
        }
    }
}
