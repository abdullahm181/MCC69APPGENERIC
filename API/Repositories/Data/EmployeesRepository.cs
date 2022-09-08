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
    public class EmployeesRepository : Repository<Employees, MyContext>
    {
        public EmployeesRepository(MyContext myContext):base(myContext)
        {

=======
    public class EmployeesRepository:IEmployees
    {
        MyContext myContext;
        public EmployeesRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.Employees.Find(id);
            if (data == null)
                return -1;

            myContext.Employees.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<Employees> Get()
        {
            var data = myContext.Employees.ToList();
            return data;
        }

        public Employees Get(int id)
        {
            var data = myContext.Employees.Find(id);
            return data;
        }

        public int Post(Employees employees)
        {
            myContext.Employees.Add(employees);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, Employees employees)
        {
            var data = myContext.Employees.Find(id);
            if (data == null)
                return -1;
            //column update
            
            data.FirstName = employees.FirstName;
            data.LastName = employees.LastName;
            data.Email = employees.Email;
            data.PhoneNumber = employees.PhoneNumber;
            data.HireDate = employees.HireDate;
            data.Job_Id = employees.Job_Id;
            data.Salary = employees.Salary;
            data.Manager_Id = employees.Manager_Id;
            data.Department_Id = employees.Department_Id;
            var result = myContext.SaveChanges();
            return result;
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
        }
    }
}
