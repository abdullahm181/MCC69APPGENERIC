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

        public JobHistoryController(JobHistoryRepository jobHistoryRepository):base(jobHistoryRepository)
        {
         
        }
        
    }
}
