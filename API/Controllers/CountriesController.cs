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
    public class CountriesController : Controller<Countries, CountriesRepository>
    {
<<<<<<< HEAD

        public CountriesController(CountriesRepository countriesRepository) : base(countriesRepository)
        {

        }
    }       
=======
        CountriesRepository countriesRepository;
        public CountriesController(CountriesRepository countriesRepository)
        {
            this.countriesRepository=countriesRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = countriesRepository.Get();
            return Ok(new { result = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }

            var data = countriesRepository.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(new { result = 200, data = data });

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Countries countries)
        {
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                if (ModelState.IsValid)
                {
                    var result = countriesRepository.Put(id, countries);
                    if (result > 0)
                        return Ok(new { result = 200, message = "successfully updated" });
                    else if (result == -1)
                        return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post(Countries countries)
        {
            if (ModelState.IsValid)
            {

                var result = countriesRepository.Post(countries);
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
                var result = countriesRepository.Delete(id);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Deleted" });
                else if (result == -1)
                    return NotFound();
            }

            return BadRequest();

        }
    }
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
}
