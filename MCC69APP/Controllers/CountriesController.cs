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
        HttpAPi<Countries> httpAPI;
        HttpAPi<Regions> httpAPIRegions;
        public CountriesController()
        {
            this.httpAPI = new HttpAPi<Countries>("Countries");
            this.httpAPIRegions = new HttpAPi<Regions>("Regions");
        }
        public IActionResult Index()
        {
            IEnumerable<Countries> countries = null;
            countries = httpAPI.Get();

            if (countries == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(countries);
        }

        public IActionResult Create() 
        {

            IEnumerable<Regions> regions = null;
            regions = httpAPIRegions.Get();
            ViewBag.Regions = new SelectList(regions, "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Countries countries)
        {
            string result = httpAPI.Create(countries);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(countries);
        }
        public IActionResult Edit(int id)
        {
            IEnumerable<Regions> regions = null;
            regions = httpAPIRegions.Get();
            ViewBag.Regions = new SelectList(regions, "Id", "Name");

            if (id == null)
            {
                return NotFound();
            }

            Countries countries = null;
            countries = httpAPI.Get(id);
            if (countries == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            
            return View(countries);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Countries countries)
        {
            string result = httpAPI.Edit(countries);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }
            return View(countries);
        }
        //Detail
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Countries countries = null;
            countries = httpAPI.Get(id);
            if (countries == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(countries);
        }

        //DELETE
        public IActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Countries countries = null;
            countries = httpAPI.Get(id);
            if (countries == null)
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }

            return View(countries);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Countries countries)
        {
            string result = httpAPI.Delete(countries);
            if (!string.IsNullOrWhiteSpace(result) && result == "200")
            {
                return RedirectToAction(nameof(Index));
            }

            return View(countries);
        }
    }
}
