using API.Context;
using API.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repositories.Data
{
    public class Repository<ObjectName, TContext> : IRepository<ObjectName>
        where ObjectName : class, IEntity
        where TContext : DbContext
    {
        TContext myContext;
        public Repository(TContext myContext)
        {
            this.myContext = myContext;
        }

        public int Delete(int id)
        {
            var data =Get(id);
            if (data == null)
                return -1;

            myContext.Set<ObjectName>().Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<ObjectName> Get()
        {
            var data = myContext.Set<ObjectName>().ToList();
            return data;
        }

        public ObjectName Get(int id)
        {
            var data = myContext.Set<ObjectName>().Find(id);
            return data;
        }

        public int Post(ObjectName objectName)
        {
            myContext.Set<ObjectName>().Add(objectName);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, ObjectName objectName)
        {
            var data = myContext.Set<ObjectName>().Find(id);
            if (data == null)
                return -1;


            //column update
            objectName.Id = id;

            myContext.Entry(data).CurrentValues.SetValues(objectName);
            //myContext.Entry(objectName).State = EntityState.Modified;
            var result = myContext.SaveChanges();
            return result;
        }
    }
}
