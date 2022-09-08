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
    public class RegionsRepository : Repository<Regions, MyContext>
    {
        public RegionsRepository(MyContext myContext): base(myContext)
        {

        }
=======
    public class RegionsRepository : IRegion
    {
        MyContext myContext;
        public RegionsRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data = myContext.Regions.Find(id);
            if (data == null)
                return -1;

            myContext.Regions.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Regions> Get()
        {
            var data = myContext.Regions.ToList();
            return data;
        }

        public Regions Get(int id)
        {
            var data = myContext.Regions.Find(id);
            return data;
        }

        public int Post(Regions regions)
        {
            myContext.Regions.Add(regions);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, Regions regions)
        {
            var data = myContext.Regions.Find(id);
            if (data == null)
                return -1;
            //column update

            data.Name = regions.Name;
            var result = myContext.SaveChanges();
            return result;
        }
        
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
    }
}
