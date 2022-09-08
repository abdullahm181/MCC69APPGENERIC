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
    public class JobsRepository : Repository<Jobs, MyContext>
    {
        public JobsRepository(MyContext myContext):base(myContext)
        {

=======
    public class JobsRepository:IJobs
    {
        MyContext myContext;
        public JobsRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Jobs.Find(id);
            if (data == null)
                return -1;

            myContext.Jobs.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Jobs> Get()
        {
            var data = myContext.Jobs.ToList();
            return data;
        }

        public Jobs Get(int id)
        {
            var data = myContext.Jobs.Find(id);
            return data;
        }

        public int Post(Jobs jobs)
        {
            myContext.Jobs.Add(jobs);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, Jobs jobs)
        {
            var data = myContext.Jobs.Find(id);
            if (data == null)
                return -1;
            //column update

            data.JobTitle = jobs.JobTitle;
            data.MinSalary = jobs.MinSalary;
            data.MaxSalary = jobs.MaxSalary;
            var result = myContext.SaveChanges();
            return result;
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
        }
    }
}
