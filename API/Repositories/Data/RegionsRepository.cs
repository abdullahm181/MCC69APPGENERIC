using API.Context;
using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class RegionsRepository : Repository<Regions, MyContext>
    {
        public RegionsRepository(MyContext myContext): base(myContext)
        {

        }
    }
}
