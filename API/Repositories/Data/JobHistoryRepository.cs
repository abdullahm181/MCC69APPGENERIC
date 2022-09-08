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
    public class JobHistoryRepository : Repository<JobHistory, MyContext>
    {
        public JobHistoryRepository(MyContext myContext):base(myContext)
        {

=======
    public class JobHistoryRepository:IJobHistory
    {
        MyContext myContext;
        public JobHistoryRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }
        public int Delete(int id)
        {
            var data = myContext.JobHistory.Find(id);
            if (data == null)
                return -1;

            myContext.JobHistory.Remove(data);
            var result = myContext.SaveChanges();
            return result;
        }

        public List<JobHistory> Get()
        {
            var data = myContext.JobHistory.ToList();
            return data;
        }

        public JobHistory Get(int id)
        {
            var data = myContext.JobHistory.Find(id);
            return data;
        }

        public int Post(JobHistory jobHistory)
        {
            myContext.JobHistory.Add(jobHistory);
            var result = myContext.SaveChanges();
            return result;
        }

        public int Put(int id, JobHistory jobHistory)
        {
            var data = myContext.JobHistory.Find(id);
            if (data == null)
                return -1;
            //column update
            data.StartDate = jobHistory.StartDate;
            data.EndDate = jobHistory.EndDate;
            data.Job_Id = jobHistory.Job_Id;
            data.Department_Id = jobHistory.Department_Id;
            data.Department_Id = jobHistory.Department_Id;
            var result = myContext.SaveChanges();
            return result;
>>>>>>> 97508de2f7342ea05654553cad75eef18e99ab85
        }
    }
}
