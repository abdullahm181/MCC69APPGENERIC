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
    public class LocationsRepository : Repository<Locations, MyContext>
    {
        public LocationsRepository(MyContext myContext) : base(myContext)
        {

        }
    }
=======
    public class LocationsRepository:ILocations
    {
        MyContext myContext;
        public LocationsRepository(MyContext myContext)
        {
            this.myContext = myContext;  
        }
        public int Delete(int id)
        {
            var data = myContext.Locations.Find(id);
            if (data == null)
                return -1;

            myContext.Locations.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Locations> Get()
        {
            var data = myContext.Locations.ToList();
            return data;
        }

        public Locations Get(int id)
        {
            var data = myContext.Locations.Find(id);
            return data;
        }

        public int Post(Locations locations)
        {
            myContext.Locations.Add(locations);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, Locations locations)
        {
            var data = myContext.Locations.Find(id);
            if (data == null)
                return -1;
            //column update

            data.StreetAddress = locations.StreetAddress;
            data.PostalCode = locations.PostalCode;
            data.City = locations.City;
            data.Country_Id = locations.Country_Id;
            var result = myContext.SaveChanges();
            return result;
        }
    }

>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
}
