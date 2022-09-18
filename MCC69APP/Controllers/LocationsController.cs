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
        HttpAPi<Locations> httpAPI;
        HttpAPi<Countries> httpAPICountries;
        public LocationsController(MyContext myContext)
        {
            this.httpAPI = new HttpAPi<Locations>("Locations");
            this.httpAPICountries = new HttpAPi<Countries>("Countries");
        }
        public IActionResult Index()
        {
            IEnumerable<Locations> locations = null;
            locations = httpAPI.Get();

            if (locations == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(locations);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Locations locations = null;
            locations = httpAPI.Get(id);
            if (locations == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(locations);
        }
        public IActionResult Create()
        {
            IEnumerable<Countries> countries = null;
            countries = httpAPICountries.Get();

            ViewData["Country_Id"] = new SelectList(countries, "Id", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StreetAddress,PostalCode,City,Country_Id")] Locations locations)
        {
            string result = httpAPI.Create(locations);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(locations);
        }

        public IActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Locations locations = null;
            locations = httpAPI.Get(id);
            if (locations == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            IEnumerable<Countries> countries = null;
            countries = httpAPICountries.Get();

            ViewBag.Countries = new SelectList(countries, "Id", "Name", locations.Country_Id);
           
            return View(locations);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Locations locations)
        {
            string result = httpAPI.Edit(locations);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Locations locations = null;
            locations = httpAPI.Get(id);
            if (locations == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(locations);
        }

        // POST: Locations/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Locations locations)
        {

            string result = httpAPI.Delete(locations);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(locations);
        }
       
    }
}
