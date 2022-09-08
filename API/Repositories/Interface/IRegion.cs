using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface IRegion
    {
        //gabisa IActionResult
        //GetAll
        List<Regions> Get();
        //GetById
        Regions Get(int id);
        //Post
        int Post(Regions regions);
        //Put
        int Put(int id, Regions regions);
        //Deleter
        int Delete(int id);
    }
}
