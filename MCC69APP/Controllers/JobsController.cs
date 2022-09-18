
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
        HttpAPi<Jobs> httpAPI;
        public JobsController(MyContext myContext)
        {
            this.httpAPI = new HttpAPi<Jobs>("Jobs");
        }
        public IActionResult Index()
        {
            var jobs = httpAPI.Get().ToList();

            if (jobs == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(jobs);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var jobs = httpAPI.Get(id);
            if (jobs == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(jobs);
        }
        public IActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,JobTitle,MinSalary,MaxSalary")] Jobs jobs)
        {
            string result = httpAPI.Create(jobs);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
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


            var jobs = httpAPI.Get(id);
            if (jobs == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(jobs);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("Id,JobTitle,MinSalary,MaxSalary")] Jobs jobs)
        {
            string result = httpAPI.Edit(jobs);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
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


            var jobs = httpAPI.Get(id);
            if (jobs == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(jobs);
        }

        // POST: Jobs/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Jobs jobs)
        {
            string result = httpAPI.Delete(jobs);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(jobs);

        }
       
    }
}
