using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Interface
{
    public interface ICountries
    {
        //gabisa IActionResult
        //GetAll
        List<Countries> Get();
        //GetById
        Countries Get(int id);
        //Post
        int Post(Countries countries);
        //Put
        int Put(int id, Countries countries);
        //Deleter
        int Delete(int id);
    }
}
