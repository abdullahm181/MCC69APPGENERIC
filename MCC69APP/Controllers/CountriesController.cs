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
    public class CountriesController : Controller
    {
        MyContext myContext;
        public CountriesController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            var data = myContext.Countries.Include(x => x.Regions).ToList();
            
            return View(data);
        }

        public IActionResult Create() 
        {
            var region = myContext.Regions.ToList();
            ViewBag.Regions = new SelectList(region, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Countries countries)
        {
            myContext.Countries.Add(countries);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Countries");
            return View();
        }
        public IActionResult Edit(int id)
        {
            var region = myContext.Regions.ToList();
            ViewBag.Regions = new SelectList(region, "Id", "Name");
            var country = myContext.Countries.Include("Regions").SingleOrDefault(x => x.Id.Equals(id));
            return View(country);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Countries countries)
        {
            myContext.Entry(countries).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Countries");
            return View();
        }
        //Detail
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = myContext.Countries.Include(x => x.Regions).FirstOrDefault(m => m.Id == id);

            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        //DELETE
        public IActionResult Delete(int id)
        {
            var data = myContext.Countries.Include(x => x.Regions).SingleOrDefault(x => x.Id.Equals(id));

            return View(data);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Countries countries)
        {
            var data = myContext.Countries.Find(countries.Id);
            myContext.Countries.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction("Index", "Countries");
            return View();
        }
    }
}
