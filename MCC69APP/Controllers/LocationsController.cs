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
    public class LocationsController : BaseController<Locations,LocationsRepository>
    {
        CountriesRepository countriesRepository;
        public LocationsController(LocationsRepository locationsRepository,CountriesRepository countriesRepository):base(locationsRepository)
        {
            this.countriesRepository = countriesRepository;
        }
        public IActionResult Index()
        {
            
            var locations = Get();

            if (locations == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(locations);
        }
        public IActionResult Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            
            var locations = Get(id);
            if (locations == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(locations);
        }
        public IActionResult Create()
        {
            ViewData["Country_Id"] = new SelectList(countriesRepository.Get(), "Id", "Name");
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,StreetAddress,PostalCode,City,Country_Id")] Locations locations)
        {
            var result = Post(locations);
            if (result == HttpStatusCode.OK)
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

            var locations = Get(id);
            if (locations == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
           

            ViewBag.Countries = new SelectList(countriesRepository.Get(), "Id", "Name", locations.Country_Id);
           
            return View(locations);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Locations locations)
        {
            var result = Put(locations);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(locations);
        }

        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            var locations = Get(id);
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

            var result = DeleteEntity(locations);
            if (result == HttpStatusCode.OK)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(locations);
        }
       
    }
}
