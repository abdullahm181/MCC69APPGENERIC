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
            
            var locations = GetAll();

            if (locations == Enumerable.Empty<Countries>())
            {
                ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
            }
            return View(locations);
        }
        
       
    }
}
