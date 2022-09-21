using MCC69APP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCC69APP.Repositories.Data
{
    public class RegionsRepository : GeneralRepository<Regions>
    {
        public RegionsRepository(string request = "Regions/") : base(request)
        {

        }
    }
}
