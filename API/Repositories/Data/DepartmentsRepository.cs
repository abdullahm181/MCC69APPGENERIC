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
    public class DepartmentsRepository : Repository<Departments, MyContext>
    {
        public DepartmentsRepository(MyContext myContext) : base(myContext)
        {

=======

    public class DepartmentsRepository:IDepartments
    {
        MyContext myContext;
        public DepartmentsRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Departments.Find(id);
            if (data == null)
                return -1;

            myContext.Departments.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Departments> Get()
        {
            var data = myContext.Departments.ToList();
            return data;
        }

        public Departments Get(int id)
        {
            var data = myContext.Departments.Find(id);
            return data;
        }

        public int Post(Departments departments)
        {
            myContext.Departments.Add(departments);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, Departments departments)
        {
            var data = myContext.Departments.Find(id);
            if (data == null)
                return -1;
            //column update

            data.Name = departments.Name;
            data.Location_Id = departments.Location_Id;
            var result = myContext.SaveChanges();
            return result;
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
        }
    }
}
