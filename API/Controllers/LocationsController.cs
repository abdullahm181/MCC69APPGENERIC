using API.Context;
using API.Models;
using API.Repositories.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : Controller<Locations, LocationsRepository>
    {
<<<<<<< HEAD

        public LocationsController(LocationsRepository locationsRepository) : base(locationsRepository)
        {
            
        }
       
=======
        LocationsRepository locationsRepository;
        public LocationsController(LocationsRepository locationsRepository)
        {
            this.locationsRepository=locationsRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = locationsRepository.Get();
            return Ok(new { result = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }

            var data = locationsRepository.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(new { result = 200, data = data });

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Locations locations)
        {
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                if (ModelState.IsValid)
                {
                    var result = locationsRepository.Put(id, locations);
                    if (result > 0)
                        return Ok(new { result = 200, message = "successfully updated" });
                    else if (result == -1)
                        return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post(Locations locations)
        {
            if (ModelState.IsValid)
            {

                var result = locationsRepository.Post(locations);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully inserted" });
            }
            return BadRequest();

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                var result = locationsRepository.Delete(id);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Deleted" });
                else if (result == -1)
                    return NotFound();
            }

            return BadRequest();

        }
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
    }
}
