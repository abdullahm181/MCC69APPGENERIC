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
    public class LocationsController : Controller
    {
        MyContext myContext;
        public LocationsController(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public IActionResult Index()
        {
            var data= myContext.Locations.Include(x => x.Countries).ToList();
            return View(data);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var data = myContext.Locations.Include(x => x.Countries).FirstOrDefault(m => m.Id == id);

           
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }
        public IActionResult Create()
        {
            ViewData["Country_Id"] = new SelectList(myContext.Countries, "Id", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StreetAddress,PostalCode,City,Country_Id")] Locations locations)
        {
            if (ModelState.IsValid)
            {
                myContext.Locations.Add(locations);
                var result = myContext.SaveChanges();
                if (result > 0)
                    return RedirectToAction(nameof(Index));

            }
            ViewData["Country_Id"] = new SelectList(myContext.Countries, "Id", "Name", locations.Country_Id);
            return View(locations);
        }

        public IActionResult Edit(int id)
        {
            var locations = myContext.Locations.Find(id);
            ViewBag.Countries = new SelectList(myContext.Countries, "Id", "Name", locations.Country_Id);
            //var country = myContext.Countries.Include("Regions").SingleOrDefault(x => x.Id.Equals(id));
            return View(locations);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Locations locations)
        {
            myContext.Entry(locations).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction(nameof(Index));
            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var data = myContext.Locations.Include(x => x.Countries).FirstOrDefault(m => m.Id == id);

            
            if (data == null)
            {
                return NotFound();
            }

            return View(data);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var data = myContext.Locations.Find(id);
            myContext.Locations.Remove(data);
            var result = myContext.SaveChanges();
            if (result > 0)
                return RedirectToAction(nameof(Index));
            return View();
            
        }
       
    }
}
