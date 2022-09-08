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
    public class JobHistoryController : Controller<JobHistory, JobHistoryRepository>
    {
<<<<<<< HEAD

        public JobHistoryController(JobHistoryRepository jobHistoryRepository):base(jobHistoryRepository)
        {
         
        }
        
=======
        JobHistoryRepository jobHistoryRepository;
        public JobHistoryController(JobHistoryRepository jobHistoryRepository)
        {
            this.jobHistoryRepository=jobHistoryRepository;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var data = jobHistoryRepository.Get();
            return Ok(new { result = 200, data = data });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                return BadRequest();
            }

            var data = jobHistoryRepository.Get(id);

            if (data == null)
            {
                return NotFound();
            }

            return Ok(new { result = 200, data = data });

        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, JobHistory jobHistory)
        {
            if (!string.IsNullOrWhiteSpace(id.ToString()))
            {
                if (ModelState.IsValid)
                {
                    var result = jobHistoryRepository.Put(id, jobHistory);
                    if (result > 0)
                        return Ok(new { result = 200, message = "successfully updated" });
                    else if (result == -1)
                        return NotFound();
                }
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post(JobHistory jobHistory)
        {
            if (ModelState.IsValid)
            {

                var result = jobHistoryRepository.Post(jobHistory);
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
                var result = jobHistoryRepository.Delete(id);
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
