using MCC69APP.Context;
using MCC69APP.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

using Newtonsoft.Json.Linq;
using MCC69APP.Repositories.Data;
using MCC69APP.Base;
using System.Net;

namespace MCC69APP.Controllers
{
    public class RegionsController : BaseController<Regions, RegionsRepository>
    {
        
        public RegionsController(RegionsRepository regionsRepository):base(regionsRepository)
        {
            
        }
        // GET ALL
        
        public IActionResult Index()
        {
            
            
            return View();

        }
        

    }
}
