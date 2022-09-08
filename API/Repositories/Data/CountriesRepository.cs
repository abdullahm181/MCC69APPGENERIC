using API.Context;
using API.Models;
<<<<<<< HEAD
=======
using API.Repositories.Interface;
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
<<<<<<< HEAD
    public class CountriesRepository : Repository<Countries, MyContext>
    {
        public CountriesRepository(MyContext myContext) : base(myContext)
        {

=======
    public class CountriesRepository : ICountries
    {
        MyContext myContext;
        public CountriesRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Countries.Find(id);
            if (data == null)
                return -1;

            myContext.Countries.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Countries> Get()
        {
            var data = myContext.Countries.ToList();
            return data;
        }

        public Countries Get(int id)
        {
            var data = myContext.Countries.Find(id);
            return data;
        }

        public int Post(Countries countries)
        {
            myContext.Countries.Add(countries);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, Countries countries)
        {
            var data = myContext.Countries.Find(id);
            if (data == null)
                return -1;
            //column update

            data.Name = countries.Name;
            data.Region_Id = countries.Region_Id;
            var result = myContext.SaveChanges();
            return result;
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
        }
    }
}
