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
    public class RegionsController : Controller<Regions, RegionsRepository>
    {
<<<<<<< HEAD

        public RegionsController(RegionsRepository regionsRepository):base(regionsRepository)
        {
            
        }

        
=======
        RegionsRepository regionsRepository;
        public RegionsController(RegionsRepository regionsRepository)
        {
            this.regionsRepository = regionsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var data = regionsRepository.Get();
            return Ok(new { result = 200, data = data});
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString())) {
                return BadRequest();
            }
            
            var data =regionsRepository.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(new { result = 200, data = data });

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, Regions regions)
        {
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                if (ModelState.IsValid)
                {
                    var result = regionsRepository.Put(id, regions);
                    if (result > 0)
                        return Ok(new { result = 200, message = "successfully updated" });
                    else if (result == -1)
                        return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post(Regions regions)
        {
            if (ModelState.IsValid) 
            {

                var result = regionsRepository.Post(regions);
                if (result > 0)
                    return Ok(new { result = 200, message="successfully inserted"});
            }
            return BadRequest();
            
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                var result = regionsRepository.Delete(id);
                if (result > 0)
                    return Ok(new { result = 200, message = "successfully Deleted" });
                else if(result==-1)
                    return NotFound();
            }
            
            return BadRequest();

        }


       
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
    }
}
